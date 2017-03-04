namespace Fliker
{
	/// <summary>
	/// Auth provider.
	/// </summary>
	public interface IAuthProvider
	{
		/// <summary>
		/// Performs an authentication
		/// </summary>
		void Auth();

		/// <summary>
		/// Represents Redirect URL when authorized
		/// </summary>
		/// <value>The redirect URL.</value>
		string RedirectURL { get; }

		/// <summary>
		/// Represents Authentication URL when authorizing
		/// </summary>
		/// <value>The auth URL.</value>
		string AuthURL { get; }

		/// <summary>
		/// Represents Application id in social network
		/// </summary>
		/// <value>The app identifier.</value>
		string AppID { get; }

		/// <summary>
		/// Represents a scope like (friends, wall, photos)
		/// </summary>
		/// <value>The scope.</value>
		string Scope { get; }

		/// <summary>
		/// Type of auth (Facebook, VK, etc)
		/// </summary>
		/// <value>The type of the auth.</value>
		AuthType AuthType { get; }
	}
}
