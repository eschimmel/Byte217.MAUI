namespace Byte217.MAUI.Models
{
    public class Thickness
    {
        public double Left { get; set; } = 0;
        public double Top { get; set; } = 0;
        public double Right { get; set; } = 0;
        public double Bottom { get; set; } = 0;

        public Thickness()
        {
        }

        public Thickness(double left, double top, double right, double bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }
}
