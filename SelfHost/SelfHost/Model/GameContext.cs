using System;
using System.Collections.Generic;
using System.Threading;
using Common;
using SelfHost.Hubs;

namespace SelfHost.Model
{
    public class GameContext : IGameContext
    {
        private readonly Connector _connector;

        public GameContext(Connector connector)
        {
            _connector = connector;
        }

        public void Connect(string id, AuthType authType)
        {
            var alreadyConnectedUserResult = UserCollection.Current.Find(c => c.Id == id && c.SocialNetwork == authType);

            if (alreadyConnectedUserResult == null)
            {
                UserCollection.Current.Add(
                    new User
                    {
                        Id = id,
                        CanBeSearched = false,
                        ConnectionId = _connector.Context.ConnectionId,
                        SocialNetwork = authType
                    });
            }
            else
            {
                alreadyConnectedUserResult.User.ConnectionId = _connector.Context.ConnectionId;
            }
        }

        public void Disconnect()
        {
            var disconnectingUser = UserCollection.Current
                .Find(c => c.ConnectionId == _connector.Context.ConnectionId);

            if (disconnectingUser == null)
                return;

            UserCollection.Current.Remove(disconnectingUser.User);
        }

        public void PushIdForSearch(string id, Mode mode)
        {
            var result = UserCollection.Current.Find(c => c.Id == id);

            if (result == null)
                return;

            var user = result.User;
            user.CanBeSearched = true;

            UserCollection.Current.Add(user, mode);

            var oponent =
                UserCollection.Current.FindNextFor(user, mode);

            if (oponent == null)
                return;

            oponent.CanBeSearched = false;
            user.CanBeSearched = false;

            var lobiId = Guid.NewGuid();
            var lobi = new Lobi(user, oponent, lobiId);

            lobi.RoundFinished += roundState =>
            {
                Console.WriteLine("RoundFinished");
                _connector.Clients.Clients(new List<string> { user.ConnectionId, oponent.ConnectionId})
                    .RoundFinished(roundState);
            };

            lobi.GameStarted += () =>
            {
                _connector.Clients.Clients(new List<string> { user.ConnectionId, oponent.ConnectionId})
                    .GameStarted();
            };

            lobi.WaitingForOponent += idToInform =>
            {
                _connector.Clients.Client(idToInform).OponentReady();
            };

            lobi.GameFinished += roundState =>
            {
                var firstResult = UserCollection.Current.Find(c => c.Id == roundState.Player1RoundState.Id);
                var secondResult = UserCollection.Current.Find(c => c.Id == roundState.Player2RoundState.Id);

                if (mode == Mode.Rate)
                {
                    firstResult.User.OponentsAlreadyPlayedWith.Add(secondResult.User);
                    secondResult.User.OponentsAlreadyPlayedWith.Add(firstResult.User);
                }

                _connector.Clients.Clients(new List<string> { user.ConnectionId, oponent.ConnectionId})
                    .GameFinished(roundState);
            };

            Lobi.Lobies.Add(lobi);

            _connector.Clients.Clients(new List<string> { user.ConnectionId, oponent.ConnectionId})
                .OponentFound(new StartGameParams(lobiId, user.Id, oponent.Id));
        }

        public void RemoveIdForSearch(string id)
        {
            var result = UserCollection.Current.Find(c => c.Id == id);

            if (result == null)
                return;

            result.User.CanBeSearched = false;
        }

        public void Pick(Gesture gesture, Guid lobiId)
        {
            var result = UserCollection.Current.Find(c => c.ConnectionId == _connector.Context.ConnectionId);

            if (result == null)
                return;

            var lobi = Lobi.Lobies.Find(c => c.LobiId == lobiId);
            lobi.Push(result.User.Id, gesture);
        }

        public void ExitLobi(Guid lobiId, string oponentId)
        {
            var lobi = Lobi.Lobies.Find(c => c.LobiId == lobiId);

            if (lobi == null)
                return;

            lock (this)
            {
                Lobi.Lobies.Remove(lobi);
            }

            var playerToInformResult = UserCollection.Current.Find(c => c.Id == oponentId);
            var playerResult = UserCollection.Current.Find(c => c.ConnectionId == _connector.Context.ConnectionId);

            //playerResult.User.OponentsToIgnore.Add(playerToInformResult.User);
            //playerToInformResult.User.OponentsToIgnore.Add(playerResult.User);

            _connector
                .Clients
                .Client(playerToInformResult.User.ConnectionId)
                .GameCancelled();
        }

        public void StartGame(Guid lobiId, string id)
        {
            var lobi = Lobi.Lobies.Find(c => c.LobiId == lobiId);
            lobi.Ready(id);
        }

        //public void IgnoreOponent(string oponentId)
        //{
        //    var oponent = UserCollection.Current.Find(c => c.Id == oponentId).User;
        //    var player = UserCollection.Current.Find(c => c.ConnectionId == _connector.Context.ConnectionId);

        //    player.User.OponentsToIgnore.AddIfNotExists(oponent);
        //    oponent.OponentsToIgnore.AddIfNotExists(player.User);
        //}

        public void PlayAgain(Guid lobiId)
        {
            throw new NotImplementedException();
        }

        public void PlayAgain(string id, string oponentId, Mode mode)
        {
            var result = UserCollection.Current.Find(c => c.Id == id);

            if (result == null)
                return;

            var user = result.User;
            user.CanBeSearched = true;

            UserCollection.Current.Add(user, mode);

            var oponent =
                UserCollection.Current.FindNextFor(user, mode);

            if (oponent == null)
                return;

            oponent.CanBeSearched = false;
            user.CanBeSearched = false;

            var lobiId = Guid.NewGuid();
            var lobi = new Lobi(user, oponent, lobiId);

            lobi.RoundFinished += roundState =>
            {
                Thread.Sleep(300);

                _connector.Clients.Clients(new List<string> { user.ConnectionId, oponent.ConnectionId })
                    .RoundFinished(roundState);
            };

            lobi.GameStarted += () =>
            {
                _connector.Clients.Clients(new List<string> { user.ConnectionId, oponent.ConnectionId })
                    .GameStarted();
            };

            lobi.WaitingForOponent += idToInform =>
            {
                _connector.Clients.Client(idToInform).OponentReady();
            };

            lobi.GameFinished += roundState =>
            {
                var firstResult = UserCollection.Current.Find(c => c.Id == roundState.Player1RoundState.Id);
                var secondResult = UserCollection.Current.Find(c => c.Id == roundState.Player2RoundState.Id);

                if (mode == Mode.Rate)
                {
                    firstResult.User.OponentsAlreadyPlayedWith.Add(secondResult.User);
                    secondResult.User.OponentsAlreadyPlayedWith.Add(firstResult.User);
                }

                

                _connector.Clients.Clients(new List<string> { user.ConnectionId, oponent.ConnectionId })
                    .GameFinished(roundState);
            };

            Lobi.Lobies.Add(lobi);

            _connector.Clients.Clients(new List<string> { user.ConnectionId, oponent.ConnectionId })
                .OponentFound(new StartGameParams(lobiId, user.Id, oponent.Id));
        }
    }
}
