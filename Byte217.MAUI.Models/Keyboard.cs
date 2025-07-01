namespace Byte217.MAUI.Models
{
    public class Keyboard
    {
        public char[] Row1 { get; set; }
        public char[] Row2 { get; set; }
        public char[] Row3 { get; set; }

        public void ToUpper()
        {
            Row1 = new string(Row1).ToUpper().ToCharArray();
            Row2 = new string(Row2).ToUpper().ToCharArray();
            Row3 = new string(Row3).ToUpper().ToCharArray();
        }

        public void ToLower()
        {
            Row1 = new string(Row1).ToLower().ToCharArray();
            Row2 = new string(Row2).ToLower().ToCharArray();
            Row3 = new string(Row3).ToLower().ToCharArray();
        }
    }
}
