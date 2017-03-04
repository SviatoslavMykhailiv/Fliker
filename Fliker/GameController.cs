using System;
using System.Threading;
using Foundation;
using UIKit;

namespace Fliker
{
	/// <summary>
	/// Defines game controller
	/// </summary>
	public partial class GameController : BaseController
	{
		enum Stars
		{
			Previous,
			Current
		}

		#region fields
		/// <summary>
		/// The oponent gesture view
		/// </summary>
		private UIImageView oponentGesture;

		/// <summary>
		/// The user gesture view
		/// </summary>
		private UIImageView userGesture;

		#endregion

		#region properties

		/// <summary>
		/// Defines whether view controller is initialized from SearchController (NewGame = true) or from PickGestureController (NewGame = false)
		/// </summary>
		/// <value><c>true</c> if new game; otherwise, <c>false</c>.</value>
		public bool Playing { get; set; }

		/// <summary>
		/// When initialized from PickGesture controller , we pass gesture which user picked
		/// </summary>
		/// <value>The gesture.</value>
		public Gesture Gesture { get; set; }

		#endregion

		/// <summary>
		/// Invokes when back button is touched, user sends a request to server to exit a lobi which he is currently in,
		/// navigates to search controller , to find another oponent
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void BackButton_TouchUpInside(UIButton sender)
		{
			RequestDispatcher.Instance.ExitLobi();
			this.PresentController<SearchController>();
		}

		/// <summary>
		/// When users are in lobi etc (currently they aren't visible for other players , if to oponents press this button they start playing)
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void StartGameButton_TouchUpInside(UIButton sender)
		{
			RequestDispatcher.Instance.StartGame();
			userCircleImage.Image = UIImage.FromFile(AssetsNames.Circle_Green);
		}

		public GameController(IntPtr handle) : base(handle)
		{
		}

		/// <summary>
		/// System method, invokes when view is about to appear
		/// </summary>
		/// <param name="animated">If set to <c>true</c> animated.</param>
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			WhenViewAppears();
		}

		#region overrides

		/// <summary>
		/// When error occurs, refresh action
		/// </summary>
		protected override void OnRefresh()
		{
			// TODO: refresh 
		}

		/// <summary>
		/// Here we're subscribing for server callbacks
		/// </summary>
		protected override void Setup()
		{
			RequestDispatcher.Instance.OponentReady += WhenOponentReady;
			RequestDispatcher.Instance.GameCancelled += WhenGameCancelled;
			RequestDispatcher.Instance.GameStarted += WhenGameStarted;
			RequestDispatcher.Instance.RoundFinished += WhenRoundFinished;
			RequestDispatcher.Instance.GameFinished += WhenGameFinished;

			InitGestureViews();
		}

		#endregion

		#region server subscribtion methods

		/// <summary>
		/// Invokes when 'OponentReady' callback received
		/// </summary>
		private void WhenOponentReady()
		{
			Console.WriteLine("WhenOponentReady - invoked");

			InvokeOnMainThread(() =>
			{
				oponentCircleImage.Image = UIImage.FromFile(AssetsNames.Circle_Green);
			});
		}

		/// <summary>
		/// Invokes when 'GameCancelled' callback received
		/// </summary>
		private void WhenGameCancelled()
		{
			Console.WriteLine("WhenGameCancelled - invoked");

			InvokeOnMainThread(() =>
			{
				this.PresentController<SearchController>();
			});
		}

		/// <summary>
		/// Invokes when 'GameStarted' callback received
		/// </summary>
		private void WhenGameStarted()
		{
			Console.WriteLine("WhenGameStarted - invoked");

			InvokeOnMainThread(() =>
			{
				this.PresentController<PickGestureController>();
			});
		}

		/// <summary>
		/// Invokes when 'RoundFinished' callback received
		/// </summary>
		/// <param name="roundState">Round state.</param>
		private void WhenRoundFinished(RoundState roundState)
		{
			Console.WriteLine("WhenRoundFinished - invoked");

			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

			InvokeOnMainThread(() =>
			{
				Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

				SetStars(roundState);

				oponentGesture.Image = GetOponentGesture(roundState);

				SetGestures(oponentGesture, View.Frame.Location.X, (View.Frame.Size.Height / 2) - 200, (finished) =>
				{
					SetResultView(roundState, (fin) =>
					{
						Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
						this.PresentController<PickGestureController>();
					});
				});
			});
		}

		/// <summary>
		/// Invokes when GameFinished callback received
		/// </summary>
		/// <param name="roundState">Round state.</param>
		private void WhenGameFinished(RoundState roundState)
		{
			Console.WriteLine("WhenGameFinished - invoked");

			InvokeOnMainThread(() =>
			{
				SetStars(roundState);

				oponentGesture.Image = GetOponentGesture(roundState);

				SetGestures(oponentGesture, View.Frame.Location.X, (View.Frame.Size.Height / 2) - 200, (finished) =>
				{
					Like(roundState);

					SetResultView(roundState, (fin) =>
					{
						if (Context.Mode == Mode.Fun)
						{
							this.PresentController<GameResultController>();
						}
						else
						{
							this.PresentController<SearchController>();
						}
					});
				});
			});

			Context.GameScope.Reset();
		}

		#endregion

		#region helper methods

		/// <summary>
		/// Inits the gesture views.
		/// </summary>
		private void InitGestureViews()
		{
			userGesture = new UIImageView
			{
				Frame = new CoreGraphics.CGRect(View.Frame.Width - 200, View.Frame.Size.Height + 200, 200, 200),
				Image = LoadUserGestureImage(Gesture)
			};

			oponentGesture = new UIImageView
			{
				Frame = new CoreGraphics.CGRect(View.Frame.Location.X, View.Frame.Location.Y - 200, 200, 200),
			};

			View.AddSubview(userGesture);
			View.AddSubview(oponentGesture);
		}

		/// <summary>
		/// Sets the result view.
		/// </summary>
		/// <param name="roundState">Round state.</param>
		private void SetResultView(RoundState roundState, UICompletionHandler finish)
		{
			var resultView = new UIImageView(View.Frame) { Alpha = 0 };

			if (roundState.WinnerId == null)
			{
				resultView.Image = UIImage.FromFile(AssetsNames.Players_Draw);
			}
			else
			{
				resultView.Image = roundState.WinnerId == Context.CurrentUser.Id
					? UIImage.FromFile(AssetsNames.Player_Win)
					: UIImage.FromFile(AssetsNames.Player_Lose);
			}

			View.AddSubview(resultView);

			UIView.AnimateNotify(duration: 0.9, delay: 0, options: UIViewAnimationOptions.CurveLinear,
								 animation: () =>
			{
				resultView.Alpha = 1;
			},
								 completion: finish);
		}

		/// <summary>
		/// Animates the result.
		/// </summary>
		/// <param name="gesture">Gesture.</param>
		/// <param name="xPos">X position.</param>
		/// <param name="yPos">Y position.</param>
		/// <param name="completion">Completion.</param>
		private void SetGestures(UIImageView gesture, nfloat xPos, nfloat yPos, UICompletionHandler completion = null)
		{
			UIView.AnimateNotify(
				duration: 0.5,
				delay: 0,
				options: UIViewAnimationOptions.CurveLinear,
				animation: () =>
			{
				gesture.Frame = new CoreGraphics.CGRect(xPos, yPos, 200, 200);
			}, completion: completion);
		}

		/// <summary>
		/// Like the specified roundState.
		/// </summary>
		/// <param name="roundState">Round state.</param>
		private void Like(RoundState roundState)
		{
			if (Context.CurrentUser.Id == roundState.WinnerId)
				return;

			try
			{
				Context.ApiProvider.Like(Context.CurrentOponent.ImageId);
			}
			catch (ConnectionException ex)
			{
				WhenError(ex.Message);
			}
		}

		/// <summary>
		/// Sets the stars.
		/// </summary>
		/// <param name="roundState">Round state.</param>
		private void SetStars(RoundState roundState)
		{
			if (roundState.Player1RoundState.Id == Context.CurrentUser.Id)
			{
				ShowUserStars(roundState.Player1RoundState.Wins, Stars.Current);
				ShowOponentStars(roundState.Player2RoundState.Wins, Stars.Current);

				Context.GameScope.PlayerWins = roundState.Player1RoundState.Wins;
				Context.GameScope.OponentWins = roundState.Player2RoundState.Wins;
			}
			else
			{
				ShowUserStars(roundState.Player2RoundState.Wins, Stars.Current);
				ShowOponentStars(roundState.Player1RoundState.Wins, Stars.Current);

				Context.GameScope.PlayerWins = roundState.Player2RoundState.Wins;
				Context.GameScope.OponentWins = roundState.Player1RoundState.Wins;
			}
		}

		/// <summary>
		/// Sets the stars.
		/// </summary>
		/// <param name="stars">Stars.</param>
		private static void SetStars(params UIImageView[] stars)
		{
			foreach (UIImageView starView in stars)
			{
				starView.Image = UIImage.FromFile(AssetsNames.Star_Yellow);
			}
		}

		/// <summary>
		/// Setting up view , when view is about to appear, some logic
		/// </summary>
		private void WhenViewAppears()
		{
			userImage.Image = UIImage.LoadFromData(NSData.FromArray(Context.CurrentUser.Image));
			userName.Text = Context.CurrentUser.FirstName;
			userImage.MakeRound();

			oponentImage.Image = UIImage.LoadFromData(NSData.FromArray(Context.CurrentOponent.Image));
			oponentName.Text = Context.CurrentOponent.FirstName;
			oponentImage.MakeRound();

			if (Playing)
			{
				startGameButton.Hidden = true;
				backButton.Hidden = true;
				oponentCircleImage.Image = UIImage.FromFile(AssetsNames.Circle_White);
				userCircleImage.Image = UIImage.FromFile(AssetsNames.Circle_White);

				SetGestures(userGesture, View.Frame.Size.Width - 200, View.Frame.Size.Height / 2);
			}
			else
			{
				userGesture.Hidden = true;
				oponentGesture.Hidden = true;
			}

			ShowUserStars(Context.GameScope.PlayerWins, Stars.Previous);
			ShowOponentStars(Context.GameScope.OponentWins, Stars.Previous);
		}

		/// <summary>
		/// Gets the oponent gesture.
		/// </summary>
		/// <returns>The oponent gesture.</returns>
		/// <param name="roundState">Round state.</param>
		private static UIImage GetOponentGesture(RoundState roundState)
		{
			var oponentGesture = roundState.Player1RoundState.Id == Context.CurrentUser.Id
			   								? roundState.Player2RoundState.Gesture
										   : roundState.Player1RoundState.Gesture;

			return LoadOponentGestureImage(oponentGesture);
		}

		/// <summary>
		/// Loads the user gesture image.
		/// </summary>
		/// <returns>The user gesture image.</returns>
		/// <param name="gesture">Gesture.</param>
		private static UIImage LoadUserGestureImage(Gesture gesture)
		{
			switch (gesture)
			{
				case Gesture.Fist:
					return UIImage.FromFile(AssetsNames.Player_Fist);
				case Gesture.Fingers:
					return UIImage.FromFile(AssetsNames.Player_Fingers);
				case Gesture.Palm:
					return UIImage.FromFile(AssetsNames.Player_Palm);
			}

			throw new ArgumentOutOfRangeException("No such gesture");
		}

		/// <summary>
		/// Loads the oponent gesture image.
		/// </summary>
		/// <returns>The oponent gesture image.</returns>
		/// <param name="gesture">Gesture.</param>
		private static UIImage LoadOponentGestureImage(Gesture gesture)
		{
			switch (gesture)
			{
				case Gesture.Fist:
					return UIImage.FromFile(AssetsNames.Oponent_Fist);
				case Gesture.Fingers:
					return UIImage.FromFile(AssetsNames.Oponent_Fingers);
				case Gesture.Palm:
					return UIImage.FromFile(AssetsNames.Oponent_Palm);
			}

			throw new ArgumentOutOfRangeException("No such gesture");
		}

		/// <summary>
		/// Shows the user stars.
		/// </summary>
		/// <param name="wins">Wins.</param>
		private void ShowUserStars(int wins, Stars setStar)
		{
			switch (setStar)
			{
				case Stars.Current:
					switch (wins)
					{
						case 1:
							SetStars(userFirstStar);
							break;
						case 2:
							SetStars(userSecondStar);
							break;
						case 3:
							SetStars(userThirdStar);
							break;
					}
					break;
				case Stars.Previous:
					switch (wins)
					{
						case 1:
							SetStars(userFirstStar);
							break;
						case 2:
							SetStars(userFirstStar, userSecondStar);
							break;
						case 3:
							SetStars(userFirstStar, userSecondStar, userThirdStar);
							break;
					}
					break;
			}
		}

		/// <summary>
		/// Shows the oponent stars.
		/// </summary>
		/// <param name="wins">Wins.</param>
		private void ShowOponentStars(int wins, Stars setStar)
		{
			switch (setStar)
			{
				case Stars.Current:
					switch (wins)
					{
						case 1:
							SetStars(oponentFirstStar);
							break;
						case 2:
							SetStars(oponentSecondStar);
							break;
						case 3:
							SetStars(oponentThirdStar);
							break;
					}
					break;
				case Stars.Previous:
					switch (wins)
					{
						case 1:
							SetStars(oponentFirstStar);
							break;
						case 2:
							SetStars(oponentFirstStar, oponentSecondStar);
							break;
						case 3:
							SetStars(oponentFirstStar, oponentSecondStar, oponentThirdStar);
							break;
					}
					break;
			}
		}

		protected override void Cleanup()
		{
			RequestDispatcher.Instance.OponentReady -= WhenOponentReady;
			RequestDispatcher.Instance.GameCancelled -= WhenGameCancelled;
			RequestDispatcher.Instance.GameStarted -= WhenGameStarted;
			RequestDispatcher.Instance.RoundFinished -= WhenRoundFinished;
			RequestDispatcher.Instance.GameFinished -= WhenGameFinished;
		}

		#endregion

	}
}