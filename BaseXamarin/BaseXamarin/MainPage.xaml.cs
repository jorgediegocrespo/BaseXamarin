using BaseXamarin.Services;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace BaseXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            IAlertDialogService alertDialogService = DependencyService.Get<IAlertDialogService>();
            await alertDialogService.ShowDialogAsync("Prueba", "Esto es una prueba", "Cerrar");
        }
    }
}
