namespace L19Vin_sTrouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string arrowHead, string fletching, decimal shaft) = GetInputForArrow();
            Component selectedArrowhead = new Component(arrowHead);
            Component selectedFletching = new Component(fletching);
            Arrow theArrow = new Arrow(selectedArrowhead, selectedFletching, shaft);
            Console.WriteLine($"Your arrow has a total cost of {theArrow.GetArrowCost()}");
            Console.WriteLine($"{"Item",-30}{"Cost",-15}");
            Console.WriteLine($"{theArrow.GetArrowhead().GetMaterial() + " arrowhead",-30}{theArrow.GetArrowhead().GetCost(),-15}");
            Console.WriteLine($"{theArrow.GetFletching().GetMaterial() + " fletching",-30}{theArrow.GetFletching().GetCost(),-15}");
            Console.WriteLine($"{theArrow.GetShaftLength() + "cm shaft",-30}{theArrow.GetShaftCost(),-15}");
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
        private Component _arrowHead;
        private Component _fletching;
        private decimal _shaftLength;
        private decimal _shaftCost;
        private decimal _arrowCost;

        public Component GetArrowhead() => _arrowHead;
        public Component GetFletching() => _fletching;
        public decimal GetShaftLength() => _shaftLength;
        public decimal GetShaftCost() => _shaftCost;
        public decimal GetArrowCost() => _arrowCost;

        public Arrow(Component arrowHead, Component fletching, decimal shaftLength)
        {
            _arrowHead = arrowHead;
            _fletching = fletching;
            _shaftLength = shaftLength;
            _shaftCost = _shaftLength * 0.05M;
            _arrowCost = _arrowHead.GetCost() + _fletching.GetCost() + _shaftCost;
        }
    }

    class Component
    {
        private string _material;
        private int _cost;
        public string GetMaterial() => _material;
        public int GetCost() => _cost;
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