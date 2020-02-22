namespace BaseXamarin
{
    using BaseXamarin.Services;
    using Xamarin.Forms;

    public partial class App : Application
    {
        private readonly ICacheService cacheService;
        private readonly ILogService logService;

        public App()
        {
            cacheService = DependencyService.Get<ICacheService>();
            logService = DependencyService.Get<ILogService>();

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
    }
}
