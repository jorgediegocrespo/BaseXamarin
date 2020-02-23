namespace BaseXamarin.Services
{
    using System.Globalization;

    public interface ILocalizeService
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo ci);
    }
}
