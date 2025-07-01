using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Byte217.MAUI.ViewModels;

namespace Byte217.MAUI.Application.Maui.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

            this.SetTitle("Byte217 MAUI Controls");
        }

        protected override void OnBindingContextChanged()
        {
            InitializeViewModel();
            base.OnBindingContextChanged();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            // width and height are the dimensions of the drawable area.
            // This excludes all the status bars, navigation bars etc.

            Microsoft.Maui.Controls.Page currentPage = Microsoft.Maui.Controls.Application.Current.CurrentPage();
            if (currentPage == this)
            { 
                if (BindingContext is MainViewModel viewModel)
                {
                    // iOS has reserved a safeArea on the borders of the screen.
                    // This must be taken into account when calculating the page layouts

                    Thickness safeArea = On<iOS>().SafeAreaInsets();
                    viewModel.CreatePageLayouts(width, height, new Models.Thickness(safeArea.Left, safeArea.Top, safeArea.Right, safeArea.Bottom));
                }

                base.OnSizeAllocated(width, height);
            }
        }

        private void InitializeViewModel()
        {
            byte platform = DeviceInfo.Current.Platform.ToByte();
            byte idiom = DeviceInfo.Current.Idiom.ToByte();

            MainViewModel viewModel = BindingContext as MainViewModel;
            viewModel.Initialize(platform, idiom);
        }

        private async void OnShowAllPressed(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(new ShellNavigationState("//TextPage"));
        }

        private async void OnSettingsPressed(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(new ShellNavigationState("//SettingsPage"));
        }

    }
}
