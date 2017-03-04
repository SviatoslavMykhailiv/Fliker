using System;

namespace Fliker
{
	/// <summary>
	/// Start game parameters.
	/// </summary>
	public class StartGameParams
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Fliker.StartGameParams"/> class.
		/// </summary>
		/// <param name="lobiId">Lobi identifier.</param>
		/// <param name="firstPlayerId">First player identifier.</param>
		/// <param name="secondPlayerId">Second player identifier.</param>
		public StartGameParams(Guid lobiId, string firstPlayerId, string secondPlayerId)
		{
			LobiId = lobiId;
			FirstPlayerId = firstPlayerId;
			SecondPlayerId = secondPlayerId;
		}

		/// <summary>
		/// Gets or sets the lobi identifier.
		/// </summary>
		/// <value>The lobi identifier.</value>
		public Guid LobiId { get; set; }

		/// <summary>
		/// Gets or sets the first player identifier.
		/// </summary>
		/// <value>The first player identifier.</value>
		public string FirstPlayerId { get; set; }

		/// <summary>
		/// Gets or sets the second player identifier.
		/// </summary>
		/// <value>The second player identifier.</value>
		public string SecondPlayerId { get; set; }
	}
}
