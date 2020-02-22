namespace BaseXamarin.Droid.Services
{
    using Android.App;
    using Android.Util;

    public static class KeyboardServiceExtensions
    {
        public static DisplayMetrics DisplayMetrics => Application.Context.Resources.DisplayMetrics;
        public static float DisplayDensity => DisplayMetrics.Density;

        public static double ToFormsScreenValue(this int androidScreenValue)
            => (double)androidScreenValue / DisplayDensity;
    }
}