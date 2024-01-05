using System.Xml;

namespace L24_TheColor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Color customColor = new Color(25, 57, 85);
            Color yellow = Color.Yellow;
            Console.WriteLine(customColor);
            Console.WriteLine(yellow);
        }
    }

    class Color
    {
        uint R { get; set; }
        uint G { get; set; }
        uint B { get; set; }
        //have to use loweCamelCase to not conflict with the forementioned propieties.
        public static Color White { get; } = new Color(255, 255, 255);
        public static Color Black { get; } = new Color(0, 0, 0);
        public static Color Red { get; } = new Color(255, 0, 0);
        public static Color Orange { get; } = new Color(255, 165, 0);
        public static Color Yellow { get; } = new Color(255, 255, 0);
        public static Color Green { get; } = new Color(0, 128, 0);
        public static Color Blue { get; } = new Color(0, 0, 255);
        public static Color Purple { get; } = new Color(128, 0, 128);

        public Color(uint red, uint green, uint blue) 
        {
            R = red;
            G = green;
            B = blue;
        }
        public override string ToString() { return $"({R}, {G}, {B})"; }
    }
}