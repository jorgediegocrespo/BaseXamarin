[assembly: Xamarin.Forms.Dependency(typeof(BaseXamarin.Services.AlertDialogService))]
namespace BaseXamarin.Services
{
	using System.Threading.Tasks;
    using Xamarin.Forms;

    public class AlertDialogService : IAlertDialogService
    {
		public async Task ShowDialogAsync(string title, string message = "", string cancel = "")
		{
			await Application.Current.MainPage.DisplayAlert(title, message, cancel);
		}

		public async Task<bool> ShowDialogConfirmationAsync(string title, string message = "", string cancel = "", string ok = "")
		{
			return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
		}

		public async Task<string> DisplayActionSheet(string title, string cancel, string[] buttons)
		{
			return await Application.Current.MainPage.DisplayActionSheet(title, cancel, null, buttons);
		}
	}
}
