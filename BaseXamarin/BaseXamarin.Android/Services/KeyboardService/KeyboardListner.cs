namespace BaseXamarin.Droid.Services
{
    using Android.Content;
    using Android.Graphics;
    using Android.Runtime;
    using Android.Views;
    using Android.Views.InputMethods;
    using Android.Widget;
    using System;

    [Register("mymd.mobile.droid.services.KeyboardListner")]
    public class KeyboardListner : Java.Lang.Object, ViewTreeObserver.IOnGlobalLayoutListener
    {
        private const float keyboardDisplayedToHiddenRatio = 0.15f;
        private static InputMethodManager inputManager;
        private double keyboardHeight;
        private bool isShowingKeyboard = false;

        public KeyboardListner()
        {
            inputManager = GetInputManager();
        }

        public KeyboardListner(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public event EventHandler<double> KeyboardWillShow;
        public event EventHandler<double> KeyboardWillHide;

        public void OnGlobalLayout()
        {
            TryCalculateKeyboardHeight();
            NotifyKeyboardToggled();
        }

        public bool IsShowingKeyboard()
        {
            if (inputManager.Handle == IntPtr.Zero)
            {
                inputManager = GetInputManager();
            }

            return inputManager.IsAcceptingText && isShowingKeyboard && inputManager.IsActive;
        }

        private static InputMethodManager GetInputManager() => (InputMethodManager)ActivityProvider.CurrentActivity.GetSystemService(Context.InputMethodService);

        private void TryCalculateKeyboardHeight()
        {
            var contentView = ActivityProvider.RootContentView;

            if (contentView == null)
            {
                return;
            }

            var windowVisibleDisplayFrame = new Rect();
            contentView.GetWindowVisibleDisplayFrame(windowVisibleDisplayFrame);

            var visibleScreenHeight = contentView.RootView.Height;
            var potentialKeyboardHeight = visibleScreenHeight - windowVisibleDisplayFrame.Bottom;

            if (potentialKeyboardHeight > visibleScreenHeight * keyboardDisplayedToHiddenRatio)
            {
                keyboardHeight = Math.Ceiling(potentialKeyboardHeight.ToFormsScreenValue());
            }
        }

        private void NotifyKeyboardToggled()
        {
            if (inputManager.Handle == IntPtr.Zero)
            {
                inputManager = GetInputManager();
            }

            if (ActivityProvider.CurrentActivity.CurrentFocus is EditText && keyboardHeight > 0 && !isShowingKeyboard && inputManager.IsActive)
            {
                isShowingKeyboard = true;
                KeyboardWillShow?.Invoke(this, keyboardHeight);
                return;
            }
            if (!(ActivityProvider.CurrentActivity.CurrentFocus is EditText) && isShowingKeyboard && inputManager.IsActive)
            {
                KeyboardWillHide?.Invoke(this, keyboardHeight);
                isShowingKeyboard = false;
                return;
            }
        }
    }
}