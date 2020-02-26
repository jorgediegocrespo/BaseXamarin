namespace BaseXamarin.Base
{
    using BaseXamarin.Services;
    using ReactiveUI;
    using System.Reactive.Disposables;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public abstract class BaseViewModel : ReactiveObject
    {
        protected readonly ILogService logService;
        protected readonly INavigationService navigationService;
        protected readonly IAlertDialogService alertDialogService;

        protected CompositeDisposable disposables;

        public BaseViewModel()
        {
            logService = DependencyService.Get<ILogService>();
            navigationService = DependencyService.Get<INavigationService>();
            alertDialogService = DependencyService.Get<IAlertDialogService>();

            CreateCommands();
        }

        public virtual Task OnAppearingAsync()
        {
            logService.Log($"Appearing {GetType().ToString()}");
            disposables = disposables ?? new CompositeDisposable();
            return Task.CompletedTask;
        }

        public virtual Task OnDisappearingAsync()
        {
            logService.Log($"Disappearing {GetType().ToString()}");
            disposables?.Dispose();
            disposables = null;
            return Task.CompletedTask;
        }

        protected virtual void CreateCommands()
        { }
    }
}
