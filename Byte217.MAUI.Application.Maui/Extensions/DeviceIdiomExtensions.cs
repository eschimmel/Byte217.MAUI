namespace Microsoft.Maui.Devices
{
    public static class DeviceIdiomExtensions
    {
        public static byte ToByte(this DeviceIdiom deviceIdiom)
        {
            byte idiom = Byte217.MAUI.Models.Constants.Idiom.Unknown;

            if (deviceIdiom == DeviceIdiom.Phone)
            {
                idiom = Byte217.MAUI.Models.Constants.Idiom.Phone;
            }

            if (deviceIdiom == DeviceIdiom.Tablet)
            {
                idiom = Byte217.MAUI.Models.Constants.Idiom.Tablet;
            }

            if (deviceIdiom == DeviceIdiom.Desktop)
            {
                idiom = Byte217.MAUI.Models.Constants.Idiom.Desktop;
            }

            return idiom;
        }
    }
}
