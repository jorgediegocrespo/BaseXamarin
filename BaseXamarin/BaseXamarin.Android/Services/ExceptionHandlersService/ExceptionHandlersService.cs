[assembly: Xamarin.Forms.Dependency(typeof(BaseXamarin.Droid.Services.ExceptionHandlersService))]
namespace BaseXamarin.Droid.Services
{
    using Android.App;
    using BaseXamarin.Services;
    using System.IO;

    public class ExceptionHandlersService : IExceptionHandlersService
    {
        public void ShowExceptionFile()
        {
            const string errorFilename = "Fatal.log";
            string libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string errorFilePath = Path.Combine(libraryPath, errorFilename);

            if (!File.Exists(errorFilePath))
            {
                return;
            }

            string errorText = File.ReadAllText(errorFilePath);
            new AlertDialog.Builder(ActivityProvider.CurrentActivity)
                .SetPositiveButton("Clear", (sender, args) =>
                {
                    File.Delete(errorFilePath);
                })
                .SetNegativeButton("Close", (sender, args) =>
                {
                    // User pressed Close.
                })
                .SetMessage(errorText)
                .SetTitle("Crash Report")
                .Show();
        }
    }
}