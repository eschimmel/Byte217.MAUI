using Byte217.MAUI.ViewModels;

namespace Byte217.MAUI.Application.Maui.Controls
{
    public partial class KeyboardSettingsTab : ContentView
    {
        public KeyboardSettingsTab()
        {
            InitializeComponent();
        }

        public KeyboardSettingsTab(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}