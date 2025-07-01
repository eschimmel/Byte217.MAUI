using Byte217.MAUI.ObservableModels;

namespace Byte217.MAUI.Models
{
    public static class KeyboardExtensions
    {
        public static ObservableKeyboard ToObservableKeyboard(this Keyboard keyboard)
        {
            if (keyboard != null)
            {
                return new ObservableKeyboard()
                {
                    Row1 = keyboard.Row1,
                    Row2 = keyboard.Row2,
                    Row3 = keyboard.Row3
                };
            }

            return null;
        }
    }
}
