using System;
using System.Threading.Tasks;

namespace Fliker
{
	public partial class GameResultController : BaseController
	{
		public GameResultController(IntPtr handle) : base(handle)
		{
		}

		protected override void Cleanup()
		{
			backToSearchButton.TouchUpInside -= OnBackToSearchButtonTouched;
			playAgainButton.TouchUpInside -= OnPlayAgainButtonTouched;
			RequestDispatcher.Instance.OponentFound -= WhenOponentFound;
		}

		protected override void OnRefresh()
		{

		}

		protected override void Setup()
		{
			backToSearchButton.TouchUpInside += OnBackToSearchButtonTouched;
			playAgainButton.TouchUpInside += OnPlayAgainButtonTouched;
			RequestDispatcher.Instance.OponentFound += WhenOponentFound;
		}

		private void WhenOponentFound(StartGameParams startGameParam)
		{
			InvokeOnMainThread(async () =>
			{
				await SetGame(startGameParam);
				this.PresentController<GameController>();
			});
		}

		private void OnPlayAgainButtonTouched(object sender, EventArgs e)
		{

		}

		private void OnBackToSearchButtonTouched(object sender, EventArgs e)
		{
			RequestDispatcher.Instance.IgnoreOponent(Context.CurrentOponent.Id);
			this.PresentController<SearchController>();
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
	}
}