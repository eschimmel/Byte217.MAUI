using Byte217.MAUI.ViewModels;

namespace Byte217.MAUI.Application.Maui.Controls
{
    public partial class HistoryTab : ContentView
    {
        public HistoryTab()
        {
            InitializeComponent();
        }

        public HistoryTab(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}