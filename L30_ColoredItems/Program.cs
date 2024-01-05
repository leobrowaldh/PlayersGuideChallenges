namespace L30_ColoredItems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ColoredItem<Sword> sword = new ColoredItem<Sword>("Sword", ConsoleColor.Blue);
            ColoredItem<Bow> bow = new ColoredItem<Bow>("Bow", ConsoleColor.Red);
            ColoredItem<Axe> axe = new ColoredItem<Axe>("Axe", ConsoleColor.Green);
            Console.WriteLine(sword);
            Console.WriteLine(bow);
            Console.WriteLine(axe);
        }
    }
    public class Sword { }
    public class Bow { }
    public class Axe { }
    public class  ColoredItem<T>
    {
        public ConsoleColor Color { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            Console.ForegroundColor = Color;
            return $"This is a {Color} {Name}";
        }
        public ColoredItem(string name, ConsoleColor color)
        {
            Name = name;
            Color = color;
        }
        public ColoredItem() { }
    }
}