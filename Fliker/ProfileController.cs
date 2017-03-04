using System;
using Foundation;
using UIKit;

namespace Fliker
{
	/// <summary>
	/// Defines controller for user info, profie
	/// </summary>
	public partial class ProfileController : BaseController
	{
		private const string LikesMode = "Mode: Likes";
		private const string FunMode = "Mode: Fun";

		#region constructors

		public ProfileController(IntPtr handle) : base(handle)
		{
		}

		#endregion

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			Boot(retry: false);
		}

		/// <summary>
		/// Loads person info, tries to connect to server
		/// </summary>
		async void Boot(bool retry)
		{
			if (LoadUserDataNeeded || retry)
			{
				try
				{
					spinner.StartAnimating();
					await RequestDispatcher.Instance.Connect(Context.Secret.Network);
					Context.CurrentUser = await Context.ApiProvider.GetUser();
				}
				catch (ConnectionException ex)
				{
					WhenError(ex.Message);
				}
				catch (Exception ex)
				{
					WhenError(ex.Message);
				}
				finally
				{
					spinner.StopAnimating();
				}
			}

			userImage.Image = UIImage.LoadFromData(NSData.FromArray(Context.CurrentUser.Image));
			userName.Text = string.Format("{0} {1}", Context.CurrentUser.FirstName, Context.CurrentUser.LastName);
		}


		#region overrides

		/// <summary>
		/// Refresh action on error message
		/// </summary>
		protected override void OnRefresh()
		{
			Boot(retry: true); 
		}

		/// <summary>
		/// Setup view components
		/// </summary>
		protected override void Setup()
		{
			userImage.MakeRound();
			spinner.HidesWhenStopped = true;
			searchButton.TouchUpInside += ShowSearchView;
			menuButton.TouchUpInside += OnExit;
			modeSwitcher.ValueChanged += OnModeChanged;
			SetSwichState();
		}

		#endregion

		#region private methods

		/// <summary>
		/// Invokes when user touches exit button on profile screen, removes user secret from cache, navigates to login screen
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		async void OnExit(object sender, EventArgs e)
		{
			try
			{
				await RequestDispatcher.Instance.Disconnect();
			}
			catch (ConnectionException ex)
			{

			}
			finally
			{
				FileCache.Instance.Remove(Secret.SECRET_CACHE_KEY);
				this.PresentController<SignController>();
			}
		}

		/// <summary>
		/// Shows search view , for searching new oponents
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void ShowSearchView(object sender, EventArgs e)
		{
			this.PresentController<SearchController>();
		}

		void OnModeChanged(object sender, EventArgs e)
		{
			if (((UISwitch)sender).On)
			{
				modeTitle.Text = FunMode;
				Context.Mode = Mode.Fun;
			}
			else
			{
				modeTitle.Text = LikesMode;
				Context.Mode = Mode.Rate;
			}
		}

		private void SetSwichState()
		{
			switch (Context.Mode)
			{
				case Mode.Fun:
					modeSwitcher.On = true;
					modeTitle.Text = FunMode;
					break;
				case Mode.Rate:
					modeSwitcher.On = false;
					modeTitle.Text = LikesMode;
					break;
				default:
					modeSwitcher.On = true;
					modeTitle.Text = FunMode;
					break;
			}
		}

		protected override void Cleanup()
		{
			
		}

		public bool LoadUserDataNeeded { get; set; }

		#endregion
	}
}