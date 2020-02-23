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

        public App()
        {
            cacheService = DependencyService.Get<ICacheService>();
            logService = DependencyService.Get<ILogService>();
            localizeService = DependencyService.Get<ILocalizeService>();

            InitLocalization();
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            logService.Start();
            cacheService.Start();
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
