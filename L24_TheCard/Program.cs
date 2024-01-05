using System.Drawing;

namespace L24_TheCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < (int)enColor.Yellow + 1; i++)
            {
                for (int j = 1; j < (int)enRank.Ampersand + 1; j++)
                {
                    Card card = new Card((enColor)i, (enRank)j);
                    Console.WriteLine(card);
                }
            }
        }
    }

    class Card
    {
        public enColor Color { get; set; }
        public enRank Rank { get; set; }
        public bool IsNumber { get; set; }
        public bool IsSymbol { get; set; }
        public Card(enColor color, enRank rank)
        {
            Color = color;
            Rank = rank;
            if ((int)rank > 10)
                IsSymbol = true;
            else IsNumber = true;
        }
        public override string ToString()
        {
            string quality = IsNumber ? "Number Card" : "Symbol Card";
            return $"The {Color} {Rank} is a {quality}";
        }

    }
    enum enColor { Red, Green, Blue, Yellow}
    enum enRank { One = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Caret, Ampersand } 
}