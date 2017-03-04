using System;
using System.Threading.Tasks;

namespace Fliker
{
	/// <summary>
	/// 
	/// here we invoke all server-side callbacks
	/// </summary>
	public class RequestDispatcher : RequestDispatcherBase
	{
		public event Action<StartGameParams> OponentFound;
		public event Action OponentReady;
		public event Action GameCancelled;
		public event Action GameStarted;
		public event Action<RoundState> RoundFinished;
		public event Action<RoundState> GameFinished;

		private RequestDispatcher()
		{
			On<StartGameParams>(ConectivityConstants.OponentFound, WhenOponentFound);
			On(ConectivityConstants.OponentReady, WhenOponentReady);
			On(ConectivityConstants.GameCancelled, WhenGameCancelled);
			On(ConectivityConstants.GameStarted, WhenGameStarted);
			On<RoundState>(ConectivityConstants.RoundFinished, WhenRoundFinished);
			On<RoundState>(ConectivityConstants.GameFinished, WhenGameFinished);
		}

		private void WhenOponentFound(StartGameParams startParameters)
		{
			OponentFound?.Invoke(startParameters);
		}

		private void WhenOponentReady()
		{
			OponentReady?.Invoke();
		}

		private void WhenGameCancelled()
		{
			GameCancelled?.Invoke();
		}

		private void WhenGameStarted()
		{
			GameStarted?.Invoke();
		}

		private void WhenRoundFinished(RoundState state)
		{
			RoundFinished?.Invoke(state);
		}

		private void WhenGameFinished(RoundState state)
		{
			GameFinished?.Invoke(state);
		}

		private static RequestDispatcher instance;

		public static RequestDispatcher Instance
		{
			get
			{
				return instance ?? (instance = new RequestDispatcher());
			}
		}

		public Task PushIdForSearch()
		{
			return Invoke(ConectivityConstants.PushIdForSearch, Context.CurrentUser.Id, Context.Mode);
		}

		public Task RemoveIdFromSearch()
		{
			return Invoke(ConectivityConstants.RemoveIdForSearch, Context.CurrentUser.Id);
		}

		public Task ExitLobi()
		{
			return Invoke(ConectivityConstants.ExitLobi, Context.CurrentLobi, Context.CurrentOponent.Id);
		}

		public Task StartGame()
		{
			return Invoke(ConectivityConstants.StartGame, Context.CurrentLobi, Context.CurrentUser.Id);
		}

		public Task PickGesture(Gesture gesture)
		{
			return Invoke(ConectivityConstants.Pick, gesture, Context.CurrentLobi);
		}

		public Task Connect(AuthType authType)
		{
			return Connect(Context.Secret.ClientId, authType);
		}

		public Task Disconnect()
		{
			return Invoke(ConectivityConstants.Disconnect);
		}

		public Task IgnoreOponent(string oponentId)
		{
			return Invoke(ConectivityConstants.IgnoreOponent, oponentId);
		}
	}
}
