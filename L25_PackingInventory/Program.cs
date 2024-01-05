using System.Diagnostics.Contracts;

namespace L25_PackingInventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pack myPack = new Pack(10, 10, 10);
            bool isThereSpaceLeft = true;
            do
            {
                Console.WriteLine("What item do you want to pack in your backpack? (enter a number)");
                Console.WriteLine("1 Arrow, 2 bow, 3 Rope, 4 Water, 5 Food, 6 Sword");
                string selectedOption = Console.ReadLine();
                switch (selectedOption)
                {
                    case "1":
                        Arrow arrow = new Arrow(0.1, 0.05);
                        isThereSpaceLeft = myPack.Add(arrow);
                        break;
                    case "2":
                        Bow bow = new Bow(1, 4);
                        isThereSpaceLeft = myPack.Add(bow);
                        break;
                    case "3":
                        Rope rope = new Rope(1, 1.5);
                        isThereSpaceLeft = myPack.Add(rope);
                        break;
                    case "4":
                        Water water = new Water(2, 3);
                        isThereSpaceLeft = myPack.Add(water);
                        break;
                    case "5":
                        Food food = new Food(1, 0.5);
                        isThereSpaceLeft = myPack.Add(food);
                        break;
                    case "6":
                        Sword sword = new Sword(5, 3);
                        isThereSpaceLeft = myPack.Add(sword);
                        break;
                }
            }
            while (isThereSpaceLeft);
            Console.WriteLine("No more space in pack.");
        }
    }
    class InventoryItem
    {
        public double Weigth { get; set; }
        public double Volume { get; set; }
        public InventoryItem(double weigth, double volume)
        {
            Weigth = weigth;
            Volume = volume;
        }
        public InventoryItem() { }
    }
    class Arrow : InventoryItem
    {
        public Arrow(double weigth, double volume) : base(weigth, volume) { }
        public Arrow() { }
    }
    class Bow : InventoryItem
    {
        public Bow(double weigth, double volume) : base(weigth, volume) { }
        public Bow() { }
    }
    class Rope : InventoryItem
    {
        public Rope(double weigth, double volume) : base(weigth, volume) { }
        public Rope() { }
    }
    class Water : InventoryItem
    {
        public Water(double weigth, double volume) : base(weigth, volume) { }
        public Water() { }
    }
    class Food : InventoryItem
    {
        public Food(double weigth, double volume) : base(weigth, volume) { }
        public Food() { }
    }
    class Sword : InventoryItem
    {
        public Sword(double weigth, double volume) : base(weigth, volume) { }
        public Sword() { }
    }
    class Pack
    {
        public double WeigthCapacity { get; }
        public double VolumeCapacity { get; }
        public int ItemCapacity { get; }
        private InventoryItem[] _items;
        public int CurrentItems { get; private set; }
        public double CurrentWeigth { get; private set; }
        public double CurrentVolume {  get; private set; }
        public Pack(int itemCapacity, double weigthCapacity, double volumeCapacity)
        {
            _items = new InventoryItem[itemCapacity];
            WeigthCapacity = weigthCapacity;
            VolumeCapacity = volumeCapacity;
            ItemCapacity = itemCapacity;
        }
        public bool Add(InventoryItem item)
        {
            if (CurrentItems >= ItemCapacity) { return false; }
            if (CurrentWeigth >= WeigthCapacity) {  return false; }
            if (CurrentVolume >= VolumeCapacity) { return false; }

            _items[CurrentItems] = item;
            CurrentItems++;
            CurrentWeigth += item.Weigth;
            CurrentVolume += item.Volume;
            return true;
        }
    }
}