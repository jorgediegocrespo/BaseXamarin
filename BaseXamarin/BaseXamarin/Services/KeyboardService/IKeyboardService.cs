namespace BaseXamarin.Services
{
    using System;

    public interface IKeyboardService
    {
        event EventHandler<double> KeyboardWillShow;
        event EventHandler<double> KeyboardWillHide;

        void RegisterForKeyboardNotifications();
        void UnRegisterForKeyboardNotifications();
        bool IsShowingKeyboard();
        void ShowKeyboard();
        void DismissKeyboard();
    }
}
