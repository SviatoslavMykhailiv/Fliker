namespace SelfHost.Model
{
    /// <summary>
    /// Player round result, this object is transfered to both players, to correctly reflect the result about 2 players
    /// </summary>
    public class PlayerRoundResult
    {
        public PlayerRoundResult(string id, Gesture gesture, int wins)
        {
            Id = id;
            Gesture = gesture;
            Wins = wins;
        }

        /// <summary>
        /// Player id
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Player Gesture
        /// </summary>
        public Gesture Gesture { get; private set; }

        /// <summary>
        /// Player count of wins
        /// </summary>
        public int Wins { get; private set; }
    }
}
