namespace L24_ThePoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(2,3);
            Point p2 = new Point(-4,0);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
    }

    class Point
    {
        public int X { get;  }
        public int Y { get;  }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point()
        {
            X = 0;
            Y = 0;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}