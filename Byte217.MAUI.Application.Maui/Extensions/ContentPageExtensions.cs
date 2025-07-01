namespace Microsoft.Maui.Controls
{
    public static class ContentPageExtensions
    {
        public static void SetTitle(this ContentPage contentPage, string title)
        {
            DevicePlatform devicePlatform = DeviceInfo.Current.Platform;
            if (devicePlatform == DevicePlatform.iOS)
            {
                contentPage.Title = title.FirstCharacterToUpper();
            }
        }
    }
}
