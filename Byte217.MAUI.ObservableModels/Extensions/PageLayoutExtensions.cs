using Byte217.MAUI.ObservableModels;

namespace Byte217.MAUI.Models
{
    public static class PageLayoutExtensions
    {
        public static ObservablePageLayout ToObservablePageLayout(this PageLayout pageLayout)
        {
            if (pageLayout != null)
            {
                return new ObservablePageLayout()
                {
                    OuterSpacing = pageLayout.OuterSpacing,
                    InnerSpacing = pageLayout.InnerSpacing,
                    RowHeight = pageLayout.RowHeight,

                    ButtonWidth = pageLayout.ButtonWidth,
                    ButtonHeight = pageLayout.ButtonHeight,
                    SpaceButtonWidth = pageLayout.SpaceButtonWidth,
                    ButtonPaddingHorizontal = pageLayout.ButtonPaddingHorizontal,
                    ButtonPaddingVertical = pageLayout.ButtonPaddingVertical,
                    ButtonCornerRadius = pageLayout.ButtonCornerRadius,

                    RightColumnWidth = pageLayout.RightColumnWidth,
                    BottomRowHeight = pageLayout.BottomRowHeight,

                    FontSize = pageLayout.FontSize,
                    LabelFontSize = pageLayout.LabelFontSize,
                    TextDisplayFontSize = pageLayout.TextDisplayFontSize,
                    TextDisplayEntryHeight = pageLayout.TextDisplayEntryHeight,
                    TextDisplayEditorHeight = pageLayout.TextDisplayEditorHeight,

                    LeftColumnWidth = pageLayout.LeftColumnWidth,
                    SettingsLeftColumnWidth = pageLayout.SettingsLeftColumnWidth,

                    Width = pageLayout.Width,
                    Height = pageLayout.Height,
                    Multiplier = pageLayout.Multiplier,
                    IsValid = pageLayout.IsValid,

                    PageLayoutType = pageLayout.PageLayoutType,
                    IsPreferred = pageLayout.IsPreferred,
                };
            }

            return null;
        }
    }
}
