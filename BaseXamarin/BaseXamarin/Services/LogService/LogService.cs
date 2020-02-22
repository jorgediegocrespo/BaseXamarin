[assembly: Xamarin.Forms.Dependency(typeof(BaseXamarin.Services.LogService))]
namespace BaseXamarin.Services
{
    using Microsoft.AppCenter;
    using Microsoft.AppCenter.Analytics;
    using Microsoft.AppCenter.Crashes;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Xamarin.Essentials;

    public class LogService : ILogService
    {
        private const string secretIOS = "";
        private const string secretDROID = "";

        public void Start()
        {
            AppCenter.Start($"ios={secretIOS};android={secretDROID};", typeof(Analytics), typeof(Crashes));

            Analytics.SetEnabledAsync(true);
            Crashes.SetEnabledAsync(true);
        }

        public void Log(string message)
        {
            Analytics.TrackEvent(message, GetDeviceProperties());
        }

        public void Log(string message, [CallerMemberName] string callerMemberName = null)
        {
            if (callerMemberName == null)
                Analytics.TrackEvent(message, GetDeviceProperties());
            else
            {
                Dictionary<string, string> logProperties = GetDeviceProperties();
                logProperties.Add("Method caller", callerMemberName);
                Analytics.TrackEvent(message, logProperties);
            }            
        }

        public void LogError(Exception ex)
        {
            Crashes.TrackError(ex, GetDeviceProperties());
        }

        public void LogError(Exception ex, [CallerMemberName] string callerMemberName = null)
        {
            if (callerMemberName == null)
                Crashes.TrackError(ex, GetDeviceProperties());
            else
            {
                Dictionary<string, string> logProperties = GetDeviceProperties();
                logProperties.Add("Method caller", callerMemberName);
                Crashes.TrackError(ex, logProperties);
            }
        }

        private Dictionary<string, string> GetDeviceProperties()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            properties.Add("Device FlowDirection", Xamarin.Forms.Device.FlowDirection.ToString());
            properties.Add("Device Idiom", Xamarin.Forms.Device.Idiom.ToString());
            properties.Add("Runtime Platform", Xamarin.Forms.Device.RuntimePlatform);
            properties.Add("Device Type", DeviceInfo.DeviceType.ToString());
            properties.Add("Device Manufacturer", DeviceInfo.Manufacturer);
            properties.Add("Device Model", DeviceInfo.Model);
            properties.Add("Device Name", DeviceInfo.Name);
            properties.Add("Device Version", DeviceInfo.Version.ToString());
            properties.Add("Device VersionString", DeviceInfo.VersionString);

            return properties;
        }
    }
}
