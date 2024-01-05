namespace L29_WarPreparations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sword shortSword = new Sword(enMaterial.Iron, enGemstone.None, 1, 0.3);
            Sword longSword = shortSword with { Length = 1.5, CrossguardWidth = 0.5 };
            Sword emeraldShortSword = shortSword with { GemStone = enGemstone.Emerald };
            Console.WriteLine(shortSword);
            Console.WriteLine(longSword);
            Console.WriteLine(emeraldShortSword);
        }
    }
    public record Sword (enMaterial Material, enGemstone GemStone, double Length, double CrossguardWidth);

    public enum enMaterial { Wood, Bronce, Iron, Steel, Binarium}
    public enum enGemstone { None, Emerald, Amber, Sapphire, Diamond, Bitstone}
}