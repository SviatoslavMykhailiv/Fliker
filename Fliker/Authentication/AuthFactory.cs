using UIKit;

namespace Fliker
{
	/// <summary>
	/// Auth factory.
	/// </summary>
	public static class AuthFactory
	{
		/// <summary>
		/// Create the specified controller and authType.
		/// </summary>
		/// <param name="controller">Controller.</param>
		/// <param name="authType">Auth type.</param>
		public static IAuthProvider Create(UIViewController controller, AuthType authType)
		{
			switch (authType)
			{
				case AuthType.FB:
					return new FBAuthProvider(controller);
				case AuthType.VK:
					return new VKAuthProvider(controller);
			}

			return null;
		}
	}
}
