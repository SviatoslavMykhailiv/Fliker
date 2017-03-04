namespace Fliker
{
	/// <summary>
	/// Conectivity constants.
	/// </summary>
	public static class ConectivityConstants
	{
		public const string Connect = nameof(Connect);
		public const string Disconnect = nameof(Disconnect);
		public const string ServiceBaseUrl = "http://192.168.1.20:5001/";

		public const string PushIdForSearch = nameof(PushIdForSearch);
		public const string RemoveIdForSearch = nameof(RemoveIdForSearch);
		public const string GameStarted = nameof(GameStarted);
		public const string OponentFound = nameof(OponentFound);
		public const string NoOponentsFound = nameof(NoOponentsFound);
		public const string OponentReady = nameof(OponentReady);
		public const string GameCancelled = nameof(GameCancelled);
		public const string ExitLobi = nameof(ExitLobi);
		public const string StartGame = nameof(StartGame);
		public const string Pick = nameof(Pick);
		public const string RoundFinished = nameof(RoundFinished);
		public const string GameFinished = nameof(GameFinished);
		public const string Draw = nameof(Draw);
		public const string IgnoreOponent = nameof(IgnoreOponent);
	}
}
