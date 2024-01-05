namespace L28_RoomCoordinates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coordinate a = new Coordinate(4, 5);
            Coordinate b = new Coordinate(5, 5);
            Coordinate c = new Coordinate(3, 6);
            Coordinate d = new Coordinate(7, 4);
            Console.WriteLine($"{a} adjacent to {b}? {a.IsAdjacent(b)}");
            Console.WriteLine($"{a} adjacent to {c}? {a.IsAdjacent(c)}");
            Console.WriteLine($"{a} adjacent to {d}? {a.IsAdjacent(d)}");
        }
    }
    public struct Coordinate
    {
        public int Row { get; }
        public int Column { get; }
        public bool IsAdjacent(Coordinate other)
        {
            if (Math.Abs(this.Row - other.Row) <= 1 && Math.Abs(this.Column - other.Column) <= 1) { return true; }
            return false;
        }
        public Coordinate(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
        public override string ToString()
        {
            return $"({Row}, {Column})";
        }
    }
}