using System;
using System.Threading;
using UIKit;

namespace Fliker
{
	/// <summary>
	/// Defines controller for picking gestures
	/// </summary>
	public partial class PickGestureController : BaseController
	{
		#region fields

		/// <summary>
		/// Countdown start number
		/// </summary>
		private int counter = 5;

		/// <summary>
		/// The timer.
		/// </summary>
		private Timer timer;

		#endregion

		public PickGestureController(IntPtr handle) : base(handle)
		{
		}

		#region Pick sign methods

		/// <summary>
		/// Picks Gesture.Palm when touched
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void PalmGestureButton_TouchUpInside(UIButton sender)
		{
			KillTimer();
			PickGesture(Gesture.Palm);
		}

		/// <summary>
		/// Picks Gesture.Fist when touched
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void FistGestureButton_TouchUpInside(UIButton sender)
		{
			KillTimer();
			PickGesture(Gesture.Fist);
		}

		/// <summary>
		/// Picks Gesture.Fingers when touched
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void FingersGestureButton_TouchUpInside(UIButton sender)
		{
			KillTimer();
			PickGesture(Gesture.Fingers);
		}

		#endregion

		#region private

		/// <summary>
		/// Picks the gesture.
		/// </summary>
		/// <param name="gesture">Gesture.</param>
		private void PickGesture(Gesture gesture)
		{
			RequestDispatcher.Instance.PickGesture(gesture);

			this.PresentController<GameController>(controller =>
			{
				controller.Playing = true;
				controller.Gesture = gesture;
			});

			KillTimer();
		}

		/// <summary>
		/// Randoms the gesture.
		/// </summary>
		/// <returns>The gesture.</returns>
		private Gesture RandomGesture()
		{
			var rand = new Random().Next(1, 3);

			switch (rand)
			{
				case 1:
					return Gesture.Fingers;
				case 2:
					return Gesture.Fist;
				case 3:
					return Gesture.Palm;
			}

			throw new ArgumentOutOfRangeException();
		}

		#endregion

		#region overrides

		/// <summary>
		/// On refresh after error ocurred
		/// </summary>
		protected override void OnRefresh()
		{
			
		}

		/// <summary>
		/// Setup this instance.
		/// </summary>
		protected override void Setup()
		{
			timer = new Timer(OnTimer, null, 0, 1000);
		}

		protected override void Cleanup()
		{
			KillTimer();
		}

		private void KillTimer()
		{
			timer?.Dispose();
			timer = null;
		}

		private void OnTimer(object state)
		{
			InvokeOnMainThread(() =>
			{
				if (counter == 0)
				{
					Console.WriteLine("Random");
					PickGesture(RandomGesture());
				}
				else
				{
					countdownLabel.Text = string.Format("{0} sec.", counter);
					counter--;
				}
			});
		}

		#endregion
	}
}