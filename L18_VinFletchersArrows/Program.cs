namespace L18_VinFletchersArrows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string arrowHead, string fletching, decimal shaft) = GetInputForArrow();
            Component selectedArrowhead = new Component(arrowHead);
            Component selectedFletching = new Component(fletching);
            Arrow theArrow = new Arrow(selectedArrowhead, selectedFletching, shaft);
            Console.WriteLine($"Your arrow has a total cost of {theArrow._arrowCost}");
            Console.WriteLine($"{"Item",-30}{"Cost",-15}");
            Console.WriteLine($"{theArrow._arrowHead._material + " arrowhead",-30}{theArrow._arrowHead._cost,-15}");
            Console.WriteLine($"{theArrow._fletching._material + " fletching",-30}{theArrow._fletching._cost,-15}");
            Console.WriteLine($"{theArrow._shaftLength + "cm shaft",-30}{theArrow._shaftCost,-15}");
        }

        private static (string, string, decimal) GetInputForArrow()
        {
            Console.WriteLine("Please choose the characteristics of the arrow you ant to buy");
            Console.Write("Select arrowhead: steel, wood, obsidiana => ");
            string selectedArrowHead = Console.ReadLine().ToLower();
            Console.Write("Select fletching: plastic, turkeyfeathers, goosefeathers => ");
            string selectedFletching = Console.ReadLine().ToLower();
            Console.WriteLine("Enter the length of your shaft in cm: (just the number, between 60 and 100)");
            string shaftLengthString = Console.ReadLine();
            decimal selectedShaftLength = decimal.Parse(shaftLengthString);
            (string, string, decimal) arrowInfo = (selectedArrowHead, selectedFletching, selectedShaftLength);
            return arrowInfo;
        }

    }

    class Arrow
    {
        public Component _arrowHead;
        public Component _fletching;
        public decimal _shaftLength;
        public decimal _shaftCost;
        public decimal _arrowCost;

        public Arrow(Component arrowHead, Component fletching, decimal shaftLength)
        {
            _arrowHead = arrowHead;
            _fletching = fletching;
            _shaftLength = shaftLength;
            _shaftCost = _shaftLength * 0.05M;
            _arrowCost = _arrowHead._cost + _fletching._cost + _shaftCost;
        }
    }

    class Component
    {
        public string _material;
        public int _cost;
        public Component(string material) 
        { 
            _material = material;
            switch (_material)
            {
                case "steel": 
                    {
                        _cost = 10;
                        break; 
                    }
                case "wood":
                    {
                        _cost = 3;
                        break;
                    }
                case "obsidiana":
                    {
                        _cost = 5;
                        break;
                    }
                case "plastic":
                    {
                        _cost = 10;
                        break;
                    }
                case "turkeyfeathers":
                    {
                        _cost = 5;
                        break;
                    }
                case "goosefeathers":
                    {
                        _cost = 3;
                        break;
                    }
                default: 
                    { 
                        Console.WriteLine("That won't work.");
                        break;
                    }
            }
        }
    }
}