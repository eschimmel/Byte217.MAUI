using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Byte217.MAUI.ViewModels;

namespace Byte217.MAUI.Application.Maui.Pages
{
    public partial class TextPage : ContentPage
    {
        public TextPage()
        {
            InitializeComponent();
        }

        public TextPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

            this.SetTitle("Byte217 MAUI Controls");
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

        private async void OnBackPressed(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(new ShellNavigationState("//MainPage"));
        }
    }
}