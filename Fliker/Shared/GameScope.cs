using System;

namespace Fliker
{
	/// <summary>
	/// Game scope.
	/// </summary>
	public class GameScope
	{
		private int playerWins;
		private int oponentWins;

		/// <summary>
		/// Gets or sets the player wins.
		/// </summary>
		/// <value>The player wins.</value>
		public int PlayerWins
		{
			get
			{
				return playerWins;
			}
			set
			{
				EnsureWinsInRange(value);
				playerWins = value;
			}
		}

		/// <summary>
		/// Gets or sets the oponent wins.
		/// </summary>
		/// <value>The oponent wins.</value>
		public int OponentWins
		{
			get
			{
				return oponentWins;
			}
			set
			{
				EnsureWinsInRange(value);
				oponentWins = value;
			}
		}

		/// <summary>
		/// Reset this instance.
		/// </summary>
		public void Reset()
		{
			PlayerWins = 0;
			OponentWins = 0;
		}

		/// <summary>
		/// Ensures the wins in range.
		/// </summary>
		/// <param name="value">Value.</param>
		private void EnsureWinsInRange(int value)
		{
			if (value < 0 || value > 3)
			{
				throw new InvalidOperationException("Number of wins can not be less that 0");
			}
		}
	}
}
