using UIKit;
using Xamarin.Auth;
using System;

namespace Fliker
{
	/// <summary>
	/// Base auth provider.
	/// </summary>
	public abstract class BaseAuthProvider : IAuthProvider
	{
		/// <summary>
		/// Controller from which authentication is performed
		/// </summary>
		protected UIViewController _controller;

		/// <summary>
		/// The authenticator.
		/// </summary>
		protected OAuth2Authenticator _authenticator;

		protected BaseAuthProvider(UIViewController controller)
		{
			_controller = controller;
		}

		public abstract string RedirectURL { get; }
		public abstract string AuthURL { get; }
		public abstract string AppID { get; }
		public abstract string Scope { get; }
		public abstract AuthType AuthType { get; }

		/// <summary>
		/// Auth this instance.
		/// </summary>
		public virtual void Auth()
		{
			_authenticator = new OAuth2Authenticator(clientId: AppID, scope: Scope, authorizeUrl: new Uri(AuthURL), redirectUrl: new Uri(RedirectURL));
			_authenticator.AllowCancel = true;
			_authenticator.Completed += OnAuthCompleted;
			_controller.PresentViewController(_authenticator.GetUI(), true, null);
		}

		/// <summary>
		/// Ons the auth completed.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs args)
		{
			_controller.DismissViewController(true, null);

			if (args.IsAuthenticated)
			{
				var token = args.Account.Properties["access_token"];
				var id = args.Account.Properties["user_id"];

				var secret = new Secret(token, id, AuthType);

				FileCache.Instance.Store(secret, Secret.SECRET_CACHE_KEY);
				Context.Secret = secret;
				Context.ApiProvider = APIFactory.Create(Context.Secret.Network);

				_controller.PresentController<ProfileController>(controller =>
				{
					controller.LoadUserDataNeeded = true;
				});
			}
		}
	}
}
