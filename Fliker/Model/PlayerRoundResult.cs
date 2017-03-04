namespace Fliker
{
	/// <summary>
	/// Player round result.
	/// </summary>
	public class PlayerRoundResult
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the gesture.
		/// </summary>
		/// <value>The gesture.</value>
		public Gesture Gesture { get; set; }

		/// <summary>
		/// Gets or sets the wins.
		/// </summary>
		/// <value>The wins.</value>
		public int Wins { get; set; }
	}
}
