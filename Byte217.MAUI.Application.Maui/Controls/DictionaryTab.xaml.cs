using Byte217.MAUI.ViewModels;

namespace Byte217.MAUI.Application.Maui.Controls
{
    public partial class DictionaryTab : ContentView
    {
        public DictionaryTab()
        {
            InitializeComponent();
        }

        public DictionaryTab(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}