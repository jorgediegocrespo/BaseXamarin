namespace BaseXamarin.Services
{
    using System.Threading.Tasks;

    public interface IAlertDialogService
    {
        Task ShowDialogAsync(string title, string message, string close);
        Task<bool> ShowDialogConfirmationAsync(string title, string message, string cancel, string ok);
        Task<string> DisplayActionSheet(string title, string cancel, string[] buttons);
    }
}
