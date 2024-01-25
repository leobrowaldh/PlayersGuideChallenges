namespace L36_TheSieve;

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
                    sieve = new Sieve(Sieve.IsEven);
                    break;
                }
            case 2:
                {
                    sieve = new Sieve(Sieve.IsPositive);
                    break;
                }
            case 3:
                {
                    sieve = new Sieve(Sieve.IsMultipleOfTen);
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

public class Sieve(Func<int, bool> judgingMethod)
{
    public Func<int, bool> IsGood { get; set; } = judgingMethod;

    public static bool IsEven(int number) => number % 2 == 0;
    public static bool IsPositive(int number) => number > 0;
    public static bool IsMultipleOfTen(int number) => number % 10 == 0;
}
