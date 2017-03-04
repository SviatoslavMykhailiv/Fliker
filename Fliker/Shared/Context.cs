using System;

namespace Fliker
{
	/// <summary>
	/// Represents shared data for all application
	/// </summary>
	public static class Context
	{
		/// <summary>
		/// Current user data
		/// </summary>
		/// <value>The current user.</value>
		public static IUser CurrentUser { get; set; }

		/// <summary>
		/// Current oponent data
		/// </summary>
		/// <value>The current oponent.</value>
		public static IUser CurrentOponent { get; set; }

		/// <summary>
		/// Current users secret
		/// </summary>
		/// <value>The secret.</value>
		public static Secret Secret { get; set; }

		/// <summary>
		/// Current Game Lobi
		/// </summary>
		/// <value>The current lobi.</value>
		public static Guid CurrentLobi { get; set; }

		/// <summary>
		/// Social network API Provider
		/// </summary>
		/// <value>The API provider.</value>
		public static IAPIProvider ApiProvider { get; set; }

		/// <summary>
		/// Gets or sets the game scope.
		/// </summary>
		/// <value>The game scope.</value>
		public static GameScope GameScope { get; set; } = new GameScope();

		/// <summary>
		/// Gets or sets the mode.
		/// </summary>
		/// <value>The mode.</value>
		public static Mode Mode { get; set; }

	}
}
