namespace Microsoft.Maui.Controls
{
    public static class ApplicationExtensions
    {
        public static Page CurrentPage(this Application application)
        {
            if (application?.Windows != null && application.Windows.Count > 0)
            {
                Window window = application.Windows[0];
                Shell shell = window.Page as Shell;

                return shell.CurrentPage;
            }

            return null;
        }
    }
}
