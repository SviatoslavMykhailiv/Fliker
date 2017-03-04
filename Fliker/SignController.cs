using System;

namespace Fliker
{
	/// <summary>
	/// Sign controller.
	/// </summary>
	public partial class SignController : BaseController
	{
		protected SignController(IntPtr handle) : base(handle)
		{
		}

		/// <summary>
		/// Logins with Facebook
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void OnFbLoginButtonTouched(object sender, EventArgs e)
		{
			//TODO : implement facebook auth
			//AuthFactory.Create(this, AuthType.FB).Auth();
		}

		/// <summary>
		/// Logins with VK
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void OnVkLoginButtonTouched(object sender, EventArgs e)
		{
			AuthFactory.Create(this, AuthType.VK).Auth();
		}

		#region overrides

		/// <summary>
		/// Ons the refresh.
		/// </summary>
		protected override void OnRefresh()
		{

		}

		/// <summary>
		/// Setup this instance.
		/// </summary>
		protected override void Setup()
		{
			vkLoginButton.TouchUpInside += OnVkLoginButtonTouched;
			fbLoginButton.TouchUpInside += OnFbLoginButtonTouched;
		}

		protected override void Cleanup()
		{

		}

		#endregion
	}
}
