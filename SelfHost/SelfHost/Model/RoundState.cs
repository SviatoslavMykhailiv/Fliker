namespace SelfHost.Model
{
    /// <summary>
    /// RoundState if sent to clients , it contains a result of player's gesture, and who won the round
    /// </summary>
    public class RoundState
    {
        public RoundState(string winnerId, PlayerRoundResult player1RoundState, PlayerRoundResult player2RoundState)
        {
            WinnerId = winnerId;
            Player1RoundState = player1RoundState;
            Player2RoundState = player2RoundState;
        }

        /// <summary>
        /// Id of winner
        /// </summary>
        public string WinnerId { get; private set; }

        /// <summary>
        /// Player 1 Round Result
        /// </summary>
        public PlayerRoundResult Player1RoundState { get; private set; }

        /// <summary>
        /// Player 2 Round Result
        /// </summary>
        public PlayerRoundResult Player2RoundState { get; private set; }
    }
}
