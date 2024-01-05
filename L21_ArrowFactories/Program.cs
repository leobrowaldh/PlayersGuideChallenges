namespace L21_ArrowFactories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please selec one of the following options to buy:");
            Console.WriteLine("1. Elite Arrow");
            Console.WriteLine("2. Beginner Arrow");
            Console.WriteLine("3. Marksman Arrow");
            Console.WriteLine("4. Customize your arrow.");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    {
                        Arrow theArrow = Arrow.CreateEliteArrow();
                        PrintArrow(theArrow);
                    }
                    break;
                case "2":
                    {
                        Arrow theArrow = Arrow.CreateBeginnerArrow();
                        PrintArrow(theArrow);
                    }
                    break;
                case "3":
                    {
                        Arrow theArrow = Arrow.CreateMarksmanArrow();
                        PrintArrow(theArrow);
                    }
                    break;
                case "4":
                    {
                        Arrow theArrow = CreateCustomArrow();
                        PrintArrow(theArrow);
                    }
                    break;
            }


           
        }

        private static Arrow CreateCustomArrow()
        {
            (string arrowHead, string fletching, decimal shaft) = GetInputForCustomArrow();
            Component selectedArrowhead = new Component(arrowHead);
            Component selectedFletching = new Component(fletching);
            Arrow theArrow = new Arrow(selectedArrowhead, selectedFletching, shaft);
            return theArrow;
        }

        private static void PrintArrow(Arrow theArrow)
        {
            Console.WriteLine($"Your arrow has a total cost of {theArrow.ArrowCost}");
            Console.WriteLine($"{"Item",-30}{"Cost",-15}");
            Console.WriteLine($"{theArrow.ArrowHead.Material + " arrowhead",-30}{theArrow.ArrowHead.Cost,-15}");
            Console.WriteLine($"{theArrow.Fletching.Material + " fletching",-30}{theArrow.Fletching.Cost,-15}");
            Console.WriteLine($"{theArrow.ShaftLength + "cm shaft",-30}{theArrow.ShaftCost,-15}");
        }

        //we could use input validation, but thats not the focus of this excercise.
        private static (string, string, decimal) GetInputForCustomArrow()
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
        public Component ArrowHead { get; set; }
        public Component Fletching { get; set; }
        public decimal ShaftLength { get; set; }
        public decimal ShaftCost { get; set; }
        public decimal ArrowCost { get; set; }

        public Arrow(Component arrowHead, Component fletching, decimal shaftLength)
        {
            ArrowHead = arrowHead;
            Fletching = fletching;
            ShaftLength = shaftLength;
            ShaftCost = ShaftLength * 0.05M;
            ArrowCost = ArrowHead.Cost + Fletching.Cost + ShaftCost;
        }

        public static Arrow CreateEliteArrow() 
        {
            Component eliteArrowhead = new Component("steel");
            Component eliteFletching = new Component("plastic");
            Arrow eliteArrow = new Arrow(eliteArrowhead, eliteFletching, 95);
            return eliteArrow;
        }
        public static Arrow CreateBeginnerArrow()
        {
            Component eliteArrowhead = new Component("wood");
            Component eliteFletching = new Component("gooseFeathers");
            Arrow beginnerArrow = new Arrow(eliteArrowhead, eliteFletching, 75);
            return beginnerArrow;
        }
        public static Arrow CreateMarksmanArrow()
        {
            Component eliteArrowhead = new Component("steel");
            Component eliteFletching = new Component("gooseFeathers");
            Arrow beginnerArrow = new Arrow(eliteArrowhead, eliteFletching, 65);
            return beginnerArrow;
        }
    }

    class Component
    {
        public string Material { get; set; }
        public int Cost { get; set; }
        public Component(string material)
        {
            Material = material;
            switch (Material)
            {
                case "steel":
                    {
                        Cost = 10;
                        break;
                    }
                case "wood":
                    {
                        Cost = 3;
                        break;
                    }
                case "obsidiana":
                    {
                        Cost = 5;
                        break;
                    }
                case "plastic":
                    {
                        Cost = 10;
                        break;
                    }
                case "turkeyfeathers":
                    {
                        Cost = 5;
                        break;
                    }
                case "goosefeathers":
                    {
                        Cost = 3;
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