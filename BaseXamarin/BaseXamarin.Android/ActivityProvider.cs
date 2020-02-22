namespace BaseXamarin.Droid
{
    using Android.App;
    using Android.Views;

    public class ActivityProvider
    {
        public static Activity CurrentActivity { get; set; }

        public static View RootContentView => CurrentActivity.FindViewById(Android.Resource.Id.Content);
    }
}