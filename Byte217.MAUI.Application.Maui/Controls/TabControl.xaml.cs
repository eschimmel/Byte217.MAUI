using Byte217.MAUI.ViewModels;

namespace Byte217.MAUI.Application.Maui.Controls
{
    public partial class TabControl : ContentView
    {
        public TabControl()
        {
            InitializeComponent();
        }

        public TabControl(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}