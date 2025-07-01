using Byte217.MAUI.ObservableModels;

namespace Byte217.MAUI.Application.Maui.Controls
{
    public partial class Button : Microsoft.Maui.Controls.Button
    {
        public static readonly BindableProperty IsCapsLockedProperty =
            BindableProperty.Create(nameof(IsCapsLocked), typeof(bool), typeof(Button), false, propertyChanged: OnIsCapsLockedChanged);

        public static readonly BindableProperty PageLayoutProperty =
            BindableProperty.Create(nameof(PageLayout), typeof(ObservablePageLayout), typeof(Button), new ObservablePageLayout(), propertyChanged: OnPageLayoutChanged);

        public static void OnIsCapsLockedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is Button button)
            {
                string text = button.Text;

                if (!string.IsNullOrEmpty(text))
                {
                    bool isCapsLocked = (bool)newValue;
                    button.Text = isCapsLocked ? text.ToUpper() : text.ToLower();
                }
            }
        }

        public static void OnPageLayoutChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is Button button)
            {
                if (newValue is ObservablePageLayout pageLayout)
                {
                    button.MinimumWidthRequest = pageLayout.ButtonWidth;
                    button.MinimumHeightRequest = pageLayout.ButtonHeight;
                    button.Padding = new Thickness(pageLayout.ButtonPaddingHorizontal, pageLayout.ButtonPaddingVertical);
                    button.FontSize = pageLayout.FontSize;
                    button.CornerRadius = pageLayout.ButtonCornerRadius;
                }
            }
        }
        public bool IsCapsLocked
        {
            get => (bool)GetValue(IsCapsLockedProperty);
            set => SetValue(IsCapsLockedProperty, value);
        }

        public ObservablePageLayout PageLayout
        {
            get => (ObservablePageLayout)GetValue(PageLayoutProperty);
            set => SetValue(PageLayoutProperty, value);
        }
    }
}
