[assembly: Xamarin.Forms.Dependency(typeof(BaseXamarin.Droid.Services.KeyboardService))]
namespace BaseXamarin.Droid.Services
{
    using Android.Content;
    using Android.Views;
    using Android.Views.InputMethods;
    using BaseXamarin.Services;
    using System;
    using System.Reactive;
    using System.Reactive.Linq;

    public class KeyboardService : IKeyboardService
    {
        private KeyboardListner keyboardListner;
        private IDisposable disposableWillShow;
        private IDisposable disposableWillHide;

        private IObservable<EventPattern<double>> willShow;
        private IObservable<EventPattern<double>> willHide;

        public event EventHandler<double> KeyboardWillShow;
        public event EventHandler<double> KeyboardWillHide;

        private static ViewTreeObserver CurrentViewTreeObserver => ActivityProvider.RootContentView.ViewTreeObserver;

        public void RegisterForKeyboardNotifications()
        {
            keyboardListner = keyboardListner ?? new KeyboardListner();
            CurrentViewTreeObserver.AddOnGlobalLayoutListener(keyboardListner);

            willShow = willShow ?? Observable.FromEventPattern<double>(h => keyboardListner.KeyboardWillShow += h, h => keyboardListner.KeyboardWillShow -= h);
            disposableWillShow = disposableWillShow ?? willShow.Subscribe(ep => KeyboardListner_KeyboardWillShow(ep.Sender, ep.EventArgs));

            willHide = willHide ?? Observable.FromEventPattern<double>(h => keyboardListner.KeyboardWillHide += h, h => keyboardListner.KeyboardWillHide -= h);
            disposableWillHide = disposableWillHide ?? willHide.Subscribe(ep => KeyboardListner_KeyboardWillHide(ep.Sender, ep.EventArgs));
        }

        public void UnRegisterForKeyboardNotifications()
        {
            disposableWillShow?.Dispose();
            disposableWillHide?.Dispose();

            disposableWillShow = null;
            disposableWillHide = null;

            CurrentViewTreeObserver.RemoveOnGlobalLayoutListener(keyboardListner);
            keyboardListner = null;
        }

        public bool IsShowingKeyboard()
        {
            return keyboardListner?.IsShowingKeyboard() ?? false;
        }

        public void ShowKeyboard()
        {
            InputMethodManager inputMethodManager = (InputMethodManager)ActivityProvider.CurrentActivity.GetSystemService(Context.InputMethodService);
            if (inputMethodManager != null)
            {
                Android.Views.View view = ActivityProvider.CurrentActivity.CurrentFocus;
                inputMethodManager.ShowSoftInput(view, ShowFlags.Implicit);
                KeyboardListner_KeyboardWillShow(this, 0);
            }
        }

        public void DismissKeyboard()
        {
            InputMethodManager inputMethodManager = (InputMethodManager)ActivityProvider.CurrentActivity.GetSystemService(Context.InputMethodService);
            if (inputMethodManager != null)
            {
                Android.OS.IBinder token = ActivityProvider.CurrentActivity.CurrentFocus?.WindowToken;
                inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None);

                ActivityProvider.CurrentActivity.Window.DecorView.ClearFocus();
            }
        }

        private void KeyboardListner_KeyboardWillHide(object sender, double e)
        {
            KeyboardWillHide?.Invoke(this, e);
        }

        private void KeyboardListner_KeyboardWillShow(object sender, double e)
        {
            KeyboardWillShow?.Invoke(this, e);
        }
    }
}