using Byte217.MAUI.ViewModels;

namespace Byte217.MAUI.Application.Maui.Controls
{
    public partial class Keyboard : ContentView
    {
        public Keyboard()
        {
            InitializeComponent();
        }

        public Keyboard(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        public void OnKeyPressed(object sender, EventArgs e)
        {
            var button = sender as Button;
            var key = button.Text;

            MainViewModel viewModel = BindingContext as MainViewModel;
            viewModel.KeyPress(key);
        }
    }
}