using System;
using System.Text;
using UIKit;

namespace Fliker
{
	/// <summary>
	/// UI helper
	/// </summary>
	public static class UIHelper
	{
		/// <summary>
		/// Makes round image view
		/// </summary>
		/// <param name="imageView">Image view.</param>
		public static void MakeRound(this UIImageView imageView)
		{
			imageView.Layer.CornerRadius = imageView.Frame.Size.Width / 2;
			imageView.ClipsToBounds = true;
		}

		public static void PresentController<TController>(this UIViewController controller, Action<TController> configurator = null)
			where TController : UIViewController
		{
			var controllerId = UIConstants.Controllers[typeof(TController).Name];
			var controllerInstance = (TController)controller.Storyboard.InstantiateViewController(controllerId);
			configurator?.Invoke(controllerInstance);
			controllerInstance.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
			controller.PresentViewControllerAsync(controllerInstance, true);
		}

		public static void Alert(this UIViewController controller, string title, string message, params UIAlertAction[] actions)
		{
			var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
			alertController.View.TintColor = UIColor.Blue;

			foreach (UIAlertAction alertAction in actions)
			{
				alertController.AddAction(alertAction);
			}
				
			controller.PresentViewController(alertController, true, null);
		}

		public static string AddDot(this StringBuilder strBuilder)
		{
			return strBuilder.Append(".").ToString();
		}

		public static string RemoveDots(this StringBuilder strBuilder)
		{
			return strBuilder.Replace(".", string.Empty).ToString();
		}
	}
}
