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
        private readonly ICacheService cacheService;
        public MainPage()
        {
            InitializeComponent();
            cacheService = DependencyService.Get<ICacheService>();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await cacheService.SetLocal<string>("Test", EnValue.Text);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            LbValue.Text = await cacheService.GetLocal<string>("Test");
        }
    }
}
