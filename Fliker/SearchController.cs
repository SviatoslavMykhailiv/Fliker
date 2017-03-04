using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UIKit;

namespace Fliker
{
	public partial class SearchController : BaseController
	{
		private Timer searchTimer;
		private int counter = 0;
		private const int MaxCount = 5;
		private StringBuilder strBuilder;

		public SearchController(IntPtr handle) : base(handle)
		{
		}

		/// <summary>
		/// Views the did appear.
		/// </summary>
		/// <param name="animated">If set to <c>true</c> animated.</param>
		public async override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			await StartSearching();
		}

		#region overrides

		/// <summary>
		/// Ons the refresh.
		/// </summary>
		protected override void OnRefresh()
		{
			//TODO : 
		}

		/// <summary>
		/// Setup this instance.
		/// </summary>
		protected override void Setup()
		{
			strBuilder = new StringBuilder(searchingText.Text);

			backButton.TouchUpInside += ToProfileView;
			RequestDispatcher.Instance.OponentFound += WhenOponentFound;

			searchTimer = new Timer((state) =>
			{
				if (counter == MaxCount)
				{
					counter = 0;

					InvokeOnMainThread(() =>
					{
						searchingText.Text = strBuilder.RemoveDots();
					});
				}
				else
				{
					InvokeOnMainThread(() =>
					{
						searchingText.Text = strBuilder.AddDot();
					});

					++counter;
				}

			}, null, 0, 500);
		}

		#endregion


		#region Subscripts 

		/// <summary>
		/// Whens the oponent found.
		/// </summary>
		/// <param name="startGameParam">Start game parameter.</param>
		private void WhenOponentFound(StartGameParams startGameParam)
		{
			InvokeOnMainThread(async () =>
			{	
				await SetGame(startGameParam);
				this.PresentController<GameController>();
			});
		}

		#endregion

		#region helper methods

		/// <summary>
		/// Starts the searching.
		/// </summary>
		/// <returns>The searching.</returns>
		private async Task StartSearching()
		{
			try
			{
				await RequestDispatcher.Instance.PushIdForSearch();
			}
			catch (ConnectionException ex)
			{
				WhenError(ex.Message);
			}
		}

		/// <summary>
		/// Sets the game.
		/// </summary>
		/// <returns>The game.</returns>
		/// <param name="param">Parameter.</param>
		private async Task SetGame(StartGameParams param)
		{
			try
			{
				Context.CurrentOponent = await Context
					.ApiProvider
					.GetUser(Context.CurrentUser.Id == param.FirstPlayerId ? param.SecondPlayerId : param.FirstPlayerId);
			}
			catch (ConnectionException ex)
			{
				WhenError(ex.Message);
			}

			Context.CurrentLobi = param.LobiId;
		}

		/// <summary>
		/// Tos the profile view.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void ToProfileView(object sender, EventArgs e)
		{
			RequestDispatcher.Instance.RemoveIdFromSearch();

			this.PresentController<ProfileController>();
		}

		protected override void Cleanup()
		{
			RequestDispatcher.Instance.OponentFound -= WhenOponentFound;
			searchTimer?.Dispose();
			searchTimer = null;
		}

		#endregion
	}
}