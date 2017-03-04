namespace Fliker
{
	/// <summary>
	/// Round state.
	/// </summary>
	public class RoundState
	{
		/// <summary>
		/// Gets or sets the winner identifier.
		/// </summary>
		/// <value>The winner identifier.</value>
		public string WinnerId { get; set; }

		/// <summary>
		/// Gets or sets the state of the player1 round.
		/// </summary>
		/// <value>The state of the player1 round.</value>
		public PlayerRoundResult Player1RoundState { get; set; }

		/// <summary>
		/// Gets or sets the state of the player2 round.
		/// </summary>
		/// <value>The state of the player2 round.</value>
		public PlayerRoundResult Player2RoundState { get; set; }
	}
}
