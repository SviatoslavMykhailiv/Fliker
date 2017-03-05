using System;
using System.Collections.Generic;
using System.Linq;

namespace SelfHost.Model
{
    public class Lobi
    {
        public PlayerState Player1State { get; set; }
        public PlayerState Player2State { get; set; }
        public Guid LobiId { get; private set; }

        public Lobi(User oponent1, User oponent2, Guid lobiId)
        {
            LobiId = lobiId;
            Player1State = new PlayerState(oponent1);    
            Player2State = new PlayerState(oponent2);    
        }

        public void Push(string id, Gesture gesture)
        {
            if (Player1State.User.Id == id)
            {
                Player1State.Gesture.Add(gesture);
            }

            if (Player2State.User.Id == id)
            {
                Player2State.Gesture.Add(gesture);
            }

            if (Player1State.Gesture.Any() && Player2State.Gesture.Any() && Player1State.Gesture.Count == Player2State.Gesture.Count)
            {  
                var winnerId = CompareGestures(Player1State, Player2State);

                if (Player1State.Wins == 3 || Player2State.Wins == 3)
                {
                    var winner = Player1State.Wins > Player2State.Wins ? Player1State.User.Id : Player2State.User.Id;

                    OnGameFinished(new RoundState(winner,
                        new PlayerRoundResult(Player1State.User.Id, Player1State.Gesture.Last(), Player1State.Wins),
                        new PlayerRoundResult(Player2State.User.Id, Player2State.Gesture.Last(), Player2State.Wins)));
                }
                else
                {
                    OnRoundFinished(new RoundState(winnerId,
                        new PlayerRoundResult(Player1State.User.Id, Player1State.Gesture.Last(), Player1State.Wins),
                        new PlayerRoundResult(Player2State.User.Id, Player2State.Gesture.Last(), Player2State.Wins)));
                }
            }
        }

        public Action<RoundState> RoundFinished;
        public Action GameStarted;
        public Action<string> WaitingForOponent;
        public Action<RoundState> GameFinished;

        private void OnRoundFinished(RoundState roundState)
        {
            RoundFinished?.Invoke(roundState);
        }

        private void OnGameFinished(RoundState roundState)
        {
            GameFinished?.Invoke(roundState);    
        }

        private static string CompareGestures(PlayerState player1State, PlayerState player2State)
        {
            var player1Gesture = player1State.Gesture.Last();
            var player2Gesture = player2State.Gesture.Last();

            if (CheckIfWin(player1Gesture, player2Gesture))
            {
                player1State.Wins++;
                return player1State.User.Id;
            }

            if(CheckIfWin(player2Gesture, player1Gesture))
            {
                player2State.Wins++;
                return player2State.User.Id;
            }

            return null;
        }

        private static bool CheckIfWin(Gesture gesture1, Gesture gesture2)
        {
            return (gesture1 == Gesture.Fist && gesture2 == Gesture.Fingers) ||
                   (gesture1 == Gesture.Palm && gesture2 == Gesture.Fist) ||
                   (gesture1 == Gesture.Fingers && gesture2 == Gesture.Palm);
        }

        public static List<Lobi> Lobies { get; } = new List<Lobi>();

        public void Ready(string id)
        {
            string idToInform = null;

            if (Player1State.User.Id == id)
            {
                Player1State.ReadyToPlay = true;
                idToInform = Player2State.User.ConnectionId;
            }

            if (Player2State.User.Id == id)
            {
                Player2State.ReadyToPlay = true;
                idToInform = Player1State.User.ConnectionId;
            }

            if (Player1State.ReadyToPlay && Player2State.ReadyToPlay)
            {
                GameStarted?.Invoke();
            }
            else
            {
                if (!string.IsNullOrEmpty(idToInform))
                {
                    WaitingForOponent?.Invoke(idToInform);
                }
            }

            WaitingForOponent?.Invoke(idToInform);
        }
    }
}
