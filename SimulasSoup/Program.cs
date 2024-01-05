namespace SimulasSoup
{
    class Program
    {
        static (Type _type, Ingredient _ingredient, Seasoning _seasoning) meal;
        static void Main(string[] args)
        {
            ChooseMealType();
            ChooseIngredient();
            ChooseSeasoning();
            Console.WriteLine($"mmmmm, {meal._seasoning} {meal._ingredient} {meal._type}");
        }

        private static void ChooseSeasoning()
        {
            Console.WriteLine("what seasoning?");
            Console.WriteLine("1 spicy, 2 salty, 3 sweet");
            int selecton = int.Parse(Console.ReadLine());
            meal._seasoning = (Seasoning)selecton;
        }

        private static void ChooseIngredient()
        {
            Console.WriteLine("what ingredient?");
            Console.WriteLine("1 mushroom, 2 chicken, 3 carrots, 4 potatoes");
            int selecton = int.Parse(Console.ReadLine());
            meal._ingredient = (Ingredient)selecton;
        }

        private static void ChooseMealType()
        {
            Console.WriteLine("what type of meal?");
            Console.WriteLine("1 soup, 2 stew, 3 gumbo");
            int selecton = int.Parse(Console.ReadLine());
            meal._type = (Type)selecton;
        }

        enum Type { soup = 1, stew, gumbo }
        enum Ingredient { mushroom = 1, chicken, carrot, potatoe }
        enum Seasoning { spicy = 1, salty, sweet }
    }
}