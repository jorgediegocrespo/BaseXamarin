namespace BaseXamarin.Services
{
    public interface IStatusBarService
    {
        void HideStatusBar();

        void ShowStatusBar();

        void ChangeColor(string colorResource);
    }
}
