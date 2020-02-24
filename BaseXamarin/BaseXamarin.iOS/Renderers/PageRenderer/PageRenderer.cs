[assembly: Xamarin.Forms.ExportRenderer(typeof(Xamarin.Forms.ContentPage), typeof(BaseXamarin.iOS.Renderers.PageRenderer))]
namespace BaseXamarin.iOS.Renderers
{
    using BaseXamarin.Styles;
    using System;
    using UIKit;
    using Xamarin.Forms.Platform.iOS;

    public class PageRenderer : Xamarin.Forms.Platform.iOS.PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
                return;

            if (Element == null)
                return;

            try
            {
                SetTheme();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error changing theme. {ex?.Message}");
            }
        }

        public override void TraitCollectionDidChange(UITraitCollection previousTraitCollection)
        {
            base.TraitCollectionDidChange(previousTraitCollection);
            if (TraitCollection.UserInterfaceStyle != previousTraitCollection?.UserInterfaceStyle)
                SetTheme();
        }

        private void SetTheme()
        {
            if (TraitCollection.UserInterfaceStyle == UIUserInterfaceStyle.Dark)
                App.Current.Resources = new DarkTheme();
            else
                App.Current.Resources = new LightTheme();
        }
    }
}