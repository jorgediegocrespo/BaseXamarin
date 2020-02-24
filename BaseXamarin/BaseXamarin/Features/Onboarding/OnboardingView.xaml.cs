namespace BaseXamarin.Features
{
    using BaseXamarin.Common;
    using BaseXamarin.Services;
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnboardingView 
    {
        public OnboardingView()
        {
            InitializeComponent();
            ManageScreenSize();
        }

        private void ManageScreenSize()
        {
            if (DeviceDisplayInfo.IsSmallScreen)
                BtnTest.Text = "Pequeña";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            IAlertDialogService alertDialogService = DependencyService.Get<IAlertDialogService>();
            await alertDialogService.ShowDialogAsync("Prueba", "Esto es una prueba", "Cerrar");
        }
    }
}