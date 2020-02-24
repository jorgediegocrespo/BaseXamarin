namespace BaseXamarin.Common
{
    public static class DeviceDisplayInfo
    {
        public static double ScreenHeight { get; set; }
        public static double ScreenWidth { get; set; }
        public static bool IsSmallScreen => ScreenHeight < 600 || ScreenWidth < 350;
    }
}
