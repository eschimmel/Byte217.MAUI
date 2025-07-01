namespace Byte217.MAUI.Models
{
    public class PageLayout
    {
        public Thickness Padding { get; set; } = new Thickness(10, 10, 10, 10);

        public double OuterSpacing { get; set; } = 10;
        public double InnerSpacing { get; set; } = 5;
        public double RowHeight { get; set; } = 44;

        public double ButtonWidth { get; set; } = 44;
        public double ButtonHeight { get; set; } = 44;
        public double SpaceButtonWidth { get; set; } = 142;
        public double ButtonPaddingHorizontal { get; set; } = 12;
        public double ButtonPaddingVertical { get; set; } = 8;
        public int ButtonCornerRadius { get; set; } = 8;

        public double RightColumnWidth { get; set; } = 100;
        public double BottomRowHeight { get; set; }

        public double FontSize { get; set; } = 16;
        public double LabelFontSize { get; set; } = 14;
        public double TextDisplayFontSize { get; set; } = 20;
        public double TextDisplayEntryHeight { get; set; } = 42;
        public double TextDisplayEditorHeight { get; set; } = 289;

        public double LeftColumnWidth { get; set; } = 600;
        public double SettingsLeftColumnWidth { get; set; }

        public double Width { get; set; }
        public double Height { get; set; }
        public double Multiplier { get; set; } = 1;
        public bool IsValid { get; set; } = false;

        public byte PageLayoutType { get; set; } = Constants.PageLayoutType.Minimal;
        public bool IsPreferred { get; set; } = false;

        public Thickness SafeArea
        {
            set
            {
                Padding.Left = Math.Max(OuterSpacing, value.Left);
                Padding.Top = Math.Max(OuterSpacing, value.Top);
                Padding.Right = Math.Max(OuterSpacing, value.Right);
                Padding.Bottom = Math.Max(OuterSpacing, value.Bottom);
            }
        }

        public double SettingsRightColumnWidth
        {
            get
            {
                return RightColumnWidth;
            }
        }
    }
}
