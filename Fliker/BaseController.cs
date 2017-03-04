using System;
using UIKit;
using CoreGraphics;

namespace Fliker
{
	/// <summary>
	/// Base controller.
	/// </summary>
	public abstract class BaseController : UIViewController
	{
		enum ShowHide
		{
			Show,
			Hide
		}

		private UIView errorAlert;
		private UILabel errorLabel;
		private UIButton refreshButton;

		protected BaseController(IntPtr handle) : base(handle)
		{
			
		}

		public sealed override void ViewDidLoad()
		{
			base.ViewDidLoad();

			CreateAlert();
			Setup();
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
			Cleanup();
		}

		/// <summary>
		/// Whens the error occurs alert is shown.
		/// </summary>
		/// <param name="errorMessage">Error message.</param>
		protected virtual void WhenError(string errorMessage)
		{
			errorLabel.Text = errorMessage;
			AnimateErrorMessage(ShowHide.Show);
		}

		#region abstraction

		protected abstract void OnRefresh();
		protected abstract void Setup();
		protected abstract void Cleanup();

		#endregion

		#region helper methods

		/// <summary>
		/// Animates the error message. Popping from bottom
		/// </summary>
		/// <param name="showHide">Show hide.</param>
		private void AnimateErrorMessage(ShowHide showHide)
		{
			int height = 0;

			switch (showHide)
			{
				case ShowHide.Show:
					height = 40;
					break;
				case ShowHide.Hide:
					height = -40;
					break;
			}

			UIView.AnimateNotify(duration: 0.3,
					 delay: 0,
					 options: UIViewAnimationOptions.CurveLinear,
					 animation: () =>
						{
							errorAlert.Frame = new CGRect(View.Frame.Location.X, View.Frame.Location.Y + View.Frame.Size.Height - height, View.Frame.Size.Width, 40);
							errorLabel.Frame = new CGRect(View.Frame.Location.X + 10, View.Frame.Location.Y + View.Frame.Size.Height - height, View.Frame.Size.Width, 40);
							refreshButton.Frame = new CGRect(View.Frame.Size.Width - 40, View.Frame.Location.Y + View.Frame.Size.Height - height, 40, 40);
						},
								 completion: null);
		}

		/// <summary>
		/// Creates the alert.
		/// </summary>
		private void CreateAlert()
		{
			errorAlert = new UIView
			{
				Frame = new CGRect(View.Frame.Location.X, View.Frame.Location.Y + View.Frame.Size.Height, View.Frame.Size.Width, 40),
				BackgroundColor = UIColor.Red,
				Alpha = (nfloat)0.3
			};

			errorLabel = new UILabel
			{
				Frame = new CGRect(View.Frame.Location.X + 10, View.Frame.Location.Y + View.Frame.Size.Height, View.Frame.Size.Width, 40),
				TextColor = UIColor.Black
			};

			refreshButton = new UIButton
			{
				Frame = new CGRect(View.Frame.Size.Width - 40, View.Frame.Location.Y + View.Frame.Size.Height, 40, 40)
			};

			refreshButton.SetImage(UIImage.FromFile("refresh.png"), UIControlState.Normal);

			refreshButton.TouchUpInside += (sender, e) =>
			{
				AnimateErrorMessage(ShowHide.Hide);
				OnRefresh();
			};

			View.AddSubview(errorLabel);
			View.AddSubview(errorAlert);
			View.AddSubview(refreshButton);
		}

		#endregion
	}
}
