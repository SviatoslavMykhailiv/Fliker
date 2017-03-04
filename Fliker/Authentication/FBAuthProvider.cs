using System;
using UIKit;

namespace Fliker
{
	/// <summary>
	/// FBA uth provider.
	/// </summary>
	public class FBAuthProvider : BaseAuthProvider
	{
		/// <summary>
		/// Gets the app identifier.
		/// </summary>
		/// <value>The app identifier.</value>
		public override string AppID
		{
			get
			{
				throw new NotImplementedException();
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
				return AuthType.FB;
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
				throw new NotImplementedException();
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
				throw new NotImplementedException();
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
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Fliker.FBAuthProvider"/> class.
		/// </summary>
		/// <param name="controller">Controller.</param>
		public FBAuthProvider(UIViewController controller) : base(controller) { }

	}
}
