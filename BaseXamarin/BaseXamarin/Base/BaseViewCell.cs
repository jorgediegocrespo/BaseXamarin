namespace BaseXamarin.Base
{
    using BaseXamarin.Services;
    using ReactiveUI;
    using ReactiveUI.XamForms;
    using System;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using Xamarin.Forms;

    public class BaseViewCell<TViewModel> : ReactiveViewCell<TViewModel> where TViewModel : class
    {
        private readonly ILogService logService;

        public BaseViewCell()
        {
            logService = DependencyService.Get<ILogService>();
            this.WhenAnyValue(x => x.ViewModel)
                .Where(x => x != null)
                .Do(PopulateInfo)
                .Subscribe();

            this.WhenActivated(d => CreateBindings(d));
        }

        protected virtual CompositeDisposable CreateBindings(CompositeDisposable disposables)
        {
            logService.Log($"Creating bindings {GetType().ToString()}");
            return disposables;
        }

        protected virtual void PopulateInfo(TViewModel viewModel)
        { }
    }
}
