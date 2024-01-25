using System.Runtime.InteropServices.Marshalling;

namespace L36_TheSieveInheritance;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("select your evaluation method");
        Console.WriteLine("1. The number is even");
        Console.WriteLine("2. The number is positive");
        Console.WriteLine("3. The number is multiple of 10");
        int selectedNumber = int.Parse(Console.ReadLine());
        Sieve sieve = null;
        switch (selectedNumber)
        {
            case 1:
                {
                    sieve = new IsEven();
                    break;
                }
            case 2:
                {
                    sieve = new IsPositive();
                    break;
                }
            case 3:
                {
                    sieve = new IsMultipleOfTen();
                    break;
                }
        }

        string selection = "";
        while (selection != "q")
        {
            Console.WriteLine("Enter a number: ");
            selection = Console.ReadLine();
            if (int.TryParse(selection, out selectedNumber))
            {
                Console.WriteLine(sieve.IsGood(selectedNumber));
            }
        }
    }
}

public abstract class Sieve
{
    public abstract bool IsGood(int number);
}
public class IsEven: Sieve
{
    public override bool IsGood(int number) => number % 2 == 0;
}
public class IsPositive : Sieve
{
    public override bool IsGood(int number) => number > 0;
}
public class IsMultipleOfTen : Sieve
{
    public override bool IsGood(int number) => number % 10 == 0;
}