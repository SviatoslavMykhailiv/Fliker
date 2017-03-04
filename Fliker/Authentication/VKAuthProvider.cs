using UIKit;

namespace Fliker
{
	/// <summary>
	/// VKA uth provider.
	/// </summary>
	public class VKAuthProvider : BaseAuthProvider
	{
		/// <summary>
		/// Gets the app identifier.
		/// </summary>
		/// <value>The app identifier.</value>
		public override string AppID
		{
			get
			{
				return "5737584";
			}
		}

		/// <summary>
		/// Gets the auth URL.
		/// </summary>
		/// <value>The auth URL.</value>
		public override string AuthURL
		{
			get
			{
				return "https://oauth.vk.com/authorize";
			}
		}

		/// <summary>
		/// Gets the redirect URL.
		/// </summary>
		/// <value>The redirect URL.</value>
		public override string RedirectURL
		{
			get
			{
				return "https://oauth.vk.com/blank.html";
			}
		}

		/// <summary>
		/// Gets the scope.
		/// </summary>
		/// <value>The scope.</value>
		public override string Scope
		{
			get
			{
				return "friends,photos,pages,wall,groups,email,offline";
			}
		}

		/// <summary>
		/// Gets the type of the auth.
		/// </summary>
		/// <value>The type of the auth.</value>
		public override AuthType AuthType
		{
			get
			{
				return AuthType.VK;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Fliker.VKAuthProvider"/> class.
		/// </summary>
		/// <param name="controller">Controller.</param>
		public VKAuthProvider(UIViewController controller) : base(controller) { }
	}
}
