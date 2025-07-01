namespace Microsoft.Maui.Devices
{
    public static class DevicePlatformExtensions
    {
        public static byte ToByte(this DevicePlatform devicePlatform)
        {
            byte platform = Byte217.MAUI.Models.Constants.Platform.Unknown;
            
            if (devicePlatform == DevicePlatform.Android)
            {
                platform = Byte217.MAUI.Models.Constants.Platform.Android;
            }

            if (devicePlatform == DevicePlatform.iOS)
            {
                platform = Byte217.MAUI.Models.Constants.Platform.iOS;
            }

            if (devicePlatform == DevicePlatform.WinUI)
            {
                platform = Byte217.MAUI.Models.Constants.Platform.WinUI;
            }

            return platform;
        }
    }
}
