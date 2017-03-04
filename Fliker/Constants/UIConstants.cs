using System;
using System.Collections.Generic;

namespace Fliker
{
	/// <summary>
	/// UIC onstants.
	/// </summary>
	public static class UIConstants
	{
		public const string ProfileViewControllerId = nameof(ProfileViewControllerId);
		public const string LoginViewControllerId = nameof(LoginViewControllerId);
		public const string SearchViewControllerId = nameof(SearchViewControllerId);
		public const string GameViewControllerId = nameof(GameViewControllerId);
		public const string PickGestureViewControllerId = nameof(PickGestureViewControllerId);
		public const string GameResultController = nameof(GameResultController);

		public static Dictionary<string, string> Controllers = new Dictionary<string, string>
		{
			{ typeof(ProfileController).Name, ProfileViewControllerId },
			{ typeof(SignController).Name, LoginViewControllerId },
			{ typeof(SearchController).Name, SearchViewControllerId },
			{ typeof(GameController).Name, GameViewControllerId },
			{ typeof(PickGestureController).Name, PickGestureViewControllerId },
			{ typeof(GameResultController).Name, GameResultController }
		};
	}
}
