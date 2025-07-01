using Byte217.MAUI.ViewModels;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Byte217.MAUI.Application.Maui.Pages
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        public SettingsPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is MainViewModel viewModel)
            {
                this.SetTitle("Settings");
            }
            
            DevicePlatform devicePlatform = DeviceInfo.Current.Platform;
            DeviceIdiom deviceIdiom = DeviceInfo.Current.Idiom;

            if (devicePlatform == DevicePlatform.iOS)
            {
                if (deviceIdiom == DeviceIdiom.Phone)
                {
                    TabBarRow.Height = 36;
                }
            }
            else
            {
                await ScrollView.ScrollToAsync(0, 0, false);
            }

            base.OnAppearing();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            Microsoft.Maui.Controls.Page currentPage = Microsoft.Maui.Controls.Application.Current.CurrentPage();
            if (currentPage == this)
            {
                if (BindingContext is MainViewModel viewModel)
                {
                    Thickness safeArea = On<iOS>().SafeAreaInsets();
                    viewModel.CreatePageLayouts(width, height, new Models.Thickness(safeArea.Left, safeArea.Top, safeArea.Right, safeArea.Bottom));
                }

                base.OnSizeAllocated(width, height);
            }
        }

        public async void OnSavePressed(object sender, EventArgs e)
        {
            MainViewModel viewModel = BindingContext as MainViewModel;
            viewModel.SaveSettingsPress();

            await Shell.Current.GoToAsync(new ShellNavigationState("//MainPage"));
        }

        public async void OnCancelPressed(object sender, EventArgs e)
        {
            MainViewModel viewModel = BindingContext as MainViewModel;
            viewModel.CancelSettingsPress();

            await Shell.Current.GoToAsync(new ShellNavigationState("//MainPage"));
        }
    }
}