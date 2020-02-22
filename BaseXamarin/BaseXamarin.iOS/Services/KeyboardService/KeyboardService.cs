[assembly: Xamarin.Forms.Dependency(typeof(BaseXamarin.iOS.Services.KeyboardService))]
namespace BaseXamarin.iOS.Services
{
    using BaseXamarin.Services;
    using Foundation;
	using System;
	using UIKit;

	public class KeyboardService : IKeyboardService
	{
		private NSObject keyboardShowObserver;
		private NSObject keyboardHideObserver;
		private bool isKeyboardShown;

		public event EventHandler<double> KeyboardWillShow;
		public event EventHandler<double> KeyboardWillHide;

		public void RegisterForKeyboardNotifications()
		{
			if (keyboardShowObserver == null)
			{
				keyboardShowObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, OnKeyboardShow);
			}
			if (keyboardHideObserver == null)
			{
				keyboardHideObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, OnKeyboardHide);
			}
		}

		public void UnRegisterForKeyboardNotifications()
		{
			isKeyboardShown = false;
			if (keyboardShowObserver != null)
			{
				NSNotificationCenter.DefaultCenter.RemoveObserver(keyboardShowObserver);
				keyboardShowObserver.Dispose();
				keyboardShowObserver = null;
			}

			if (keyboardHideObserver != null)
			{
				NSNotificationCenter.DefaultCenter.RemoveObserver(keyboardHideObserver);
				keyboardHideObserver.Dispose();
				keyboardHideObserver = null;
			}
		}

		public bool IsShowingKeyboard()
		{
			return isKeyboardShown;
		}

		public void ShowKeyboard()
		{
		}

		public void DismissKeyboard()
		{
			UIApplication.SharedApplication.KeyWindow.EndEditing(true);
		}

		protected virtual void OnKeyboardShow(NSNotification notification)
		{
			if (isKeyboardShown)
			{
				return;
			}

			var rect = UIKeyboard.FrameEndFromNotification(notification);
			KeyboardWillShow?.Invoke(this, rect.Height);
		}

		private void OnKeyboardHide(NSNotification notification)
		{
			isKeyboardShown = false;

			var rect = UIKeyboard.FrameEndFromNotification(notification);
			KeyboardWillHide?.Invoke(this, rect.Height);
		}
	}
}