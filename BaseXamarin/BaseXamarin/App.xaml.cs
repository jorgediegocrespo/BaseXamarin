namespace BaseXamarin
{
    using BaseXamarin.Resources;
    using BaseXamarin.Services;
    using System.Globalization;
    using Xamarin.Forms;

    public partial class App : Application
    {
        private readonly ICacheService cacheService;
        private readonly ILogService logService;
        private readonly ILocalizeService localizeService;
        private readonly IExceptionHandlersService exceptionHandlersService;

        public App()
        {
            cacheService = DependencyService.Get<ICacheService>();
            logService = DependencyService.Get<ILogService>();
            localizeService = DependencyService.Get<ILocalizeService>();
            exceptionHandlersService = DependencyService.Get<IExceptionHandlersService>();

            InitLocalization();
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            logService.Start();
            cacheService.Start();

#if DEBUG
            exceptionHandlersService.ShowExceptionFile();
#endif
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void InitLocalization()
        {
            CultureInfo currentCultureInfo = localizeService.GetCurrentCultureInfo();
            AppResources.Culture = currentCultureInfo;
            localizeService.SetLocale(currentCultureInfo);
        }
    }
}
