using System;

namespace SelfHost.Model
{
    /// <summary>
    /// When game is about to start, this object is sent to clients
    /// </summary>
    public class StartGameParams
    {
        public StartGameParams(Guid lobiId, string firstPlayerId, string secondPlayerId)
        {
            FirstPlayerId = firstPlayerId;
            SecondPlayerId = secondPlayerId;
            LobiId = lobiId;
        }

        /// <summary>
        /// Id
        /// </summary>
        public string FirstPlayerId { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public string SecondPlayerId { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid LobiId { get; protected set; }
    }
}
