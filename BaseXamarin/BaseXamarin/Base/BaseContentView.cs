namespace BaseXamarin.Base
{
    using BaseXamarin.Services;
    using System.Reactive.Disposables;
    using Xamarin.Forms;

    public class BaseContentView 
    {
        protected readonly ILogService logService;
        protected CompositeDisposable disposables;

        public BaseContentView()
        {
            logService = DependencyService.Get<ILogService>();
            disposables = new CompositeDisposable();
        }

        ~BaseContentView()
        {
            disposables?.Dispose();
            disposables = null;
        }
    }
}
