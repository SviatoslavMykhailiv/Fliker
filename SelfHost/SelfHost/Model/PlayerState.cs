using System.Collections.Generic;

namespace SelfHost.Model
{
    /// <summary>
    /// Player state, comes from client
    /// </summary>
    public class PlayerState
    {
        public PlayerState(User user)
        {
            User = user;
            Gesture = new List<Gesture>();
        }

        /// <summary>
        /// User
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gestures per one game
        /// </summary>
        public List<Gesture> Gesture { get; set; }

        /// <summary>
        /// If ready to play
        /// </summary>
        public bool ReadyToPlay { get; set; }

        /// <summary>
        /// Count of wins
        /// </summary>
        public int Wins { get; set; }
    }
}
