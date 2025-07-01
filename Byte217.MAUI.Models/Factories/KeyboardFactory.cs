using Byte217.MAUI.Models.Constants;

namespace Byte217.MAUI.Models.Factories
{
    public class KeyboardFactory : IKeyboardFactory
    {
        public KeyboardFactory()
        {
        }

        public Keyboard CreateKeyboard()
        {
            return new Keyboard()
            {
                Row1 = "qwertyuiop".ToCharArray(),
                Row2 = "asdfghjkl'".ToCharArray(),
                Row3 = "zxcvbnm,.?".ToCharArray()
            };
        }
    }
}
