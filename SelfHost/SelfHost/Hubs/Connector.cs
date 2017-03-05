using System;
using System.Diagnostics;
using Common;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SelfHost.Model;

namespace SelfHost.Hubs
{
    [HubName(nameof(Connector))]
    public class Connector : Hub, IGameContext
    {
        static int counter = 0;

        private readonly IGameContext _gameContext;

        public Connector()
        {
            _gameContext = new GameContext(this);    
        }

        [HubMethodName(nameof(Connect))]
        public void Connect(string id, AuthType authType)
        {
            _gameContext.Connect(id, authType);
        }

        [HubMethodName(nameof(Disconnect))]
        public void Disconnect()
        {
            _gameContext.Disconnect();
        }

        [HubMethodName(nameof(PushIdForSearch))]
        public void PushIdForSearch(string id, Mode mode)
        {
            _gameContext.PushIdForSearch(id, mode);
        }

        [HubMethodName(nameof(RemoveIdForSearch))]
        public void RemoveIdForSearch(string id)
        {
            _gameContext.RemoveIdForSearch(id);
        }

        [HubMethodName(nameof(Pick))]
        public void Pick(Gesture gesture, Guid lobiId)
        {
            counter++;

            Console.WriteLine("Pick - invoked");
            Console.WriteLine($"{counter} ---------------------------");

            _gameContext.Pick(gesture, lobiId);
        }

        [HubMethodName(nameof(ExitLobi))]
        public void ExitLobi(Guid lobiId, string oponentId)
        {
            _gameContext.ExitLobi(lobiId, oponentId);
        }

        [HubMethodName(nameof(StartGame))]
        public void StartGame(Guid lobiId, string id)
        {
            _gameContext.StartGame(lobiId, id);
        }

        [HubMethodName(nameof(IgnoreOponent))]
        public void IgnoreOponent(string oponentId)
        {
            //_gameContext.IgnoreOponent(oponentId);
        }

        [HubMethodName(nameof(PlayAgain))]
        public void PlayAgain(Guid lobiId)
        {
            _gameContext.PlayAgain(lobiId);
        }
    }
}
