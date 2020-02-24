namespace BaseXamarin.Features
{
    using BaseXamarin.Common;
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
            { }
        }
    }
}