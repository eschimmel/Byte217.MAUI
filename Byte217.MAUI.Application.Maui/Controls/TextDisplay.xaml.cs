using Byte217.MAUI.ViewModels;
using Byte217.MAUI.Application.Maui.Constants;

namespace Byte217.MAUI.Application.Maui.Controls
{
    public partial class TextDisplay : ContentView
    {
        public static readonly BindableProperty ModeProperty =
            BindableProperty.Create(nameof(Mode), typeof(string), typeof(TextDisplay), propertyChanged: OnModeChanged);

        public TextDisplay()
        {
            InitializeComponent();
        }

        public TextDisplay(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
        
        private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            double scrollViewWidth = TextEntryScrollView.Width;
            double textEntryWidth = TextEntry.Width;

            if (textEntryWidth > scrollViewWidth)
            {
                InvalidateMeasure();
                await Task.Delay(50);

                await TextEntryScrollView.ScrollToAsync(textEntryWidth + 1000, 0, false);
                await EditorScrollView.ScrollToAsync(0, 0, false);
            }
        }

        private static void OnModeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            TextDisplay display = (TextDisplay)bindable;
            string mode = (string)newValue;

            display.Mode = mode;

            display.Compact.IsVisible = (mode == TextDisplayMode.Compact);
            display.Full.IsVisible = (mode == TextDisplayMode.Full);
        }

        public string Mode
        {
            get => (string)GetValue(ModeProperty);
            set => SetValue(ModeProperty, value);
        }
    }
}