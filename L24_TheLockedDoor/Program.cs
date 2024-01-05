
namespace L24_TheLockedDoor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What password do you want to set on your door?");
            string password = Console.ReadLine();
            Door door = new Door(password);
            string selection = "0";
            do
            {
                Console.WriteLine($"The door is {door.State}, What do you want to do?");
                if(door.State == enState.Closed)
                {
                    Console.Write("1 Open, 2 Lock 3 Change Password 0 Quit");
                    selection = Console.ReadLine();
                    if(selection == "1") { door.State = enState.Open; }
                    else if(selection == "2") { door.State = enState.Locked; }
                    else if(selection == "3") { door.ChangeCode(); }
                }
                else if(door.State == enState.Open)
                {
                    Console.WriteLine("1 Close 2 Change Password 0 Quit");
                    selection = Console.ReadLine();
                    if(selection == "1") { door.State = enState.Closed; }
                    else if(selection == "2") { door.ChangeCode(); }
                }
                else if (door.State == enState.Locked)
                {
                    Console.WriteLine("1 Unlock 2 Change Password 0 Quit");
                    selection = Console.ReadLine();
                    if (selection == "1") { door.Unlock(); }
                    else if (selection == "2") { door.ChangeCode(); }
                }
            }
            while (selection != "0");
        }
    }
    class Door
    {
        public enState State { get; set; }
        public string Code { get; private set; }
        public void Unlock() 
        {
            int attempts = 0;
            do
            {
                Console.WriteLine("Enter the password and the door will open!");
                string enteredPassword = Console.ReadLine();
                if (enteredPassword == Code)
                {
                    State = enState.Closed;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Password! Next time i will throw your head agains the door to try to open it mr. Took!!");
                    attempts++;
                }
            }
            while (attempts != 5);

            if (attempts == 5)
            {
                Console.WriteLine("Too many mistakes! If your head doesnt open the door, at least i will get rid of your stupid questions!");
                return;
            }
        }
        public Door(string passcode)
        {
            Random rnd = new Random();
            State = (enState)rnd.Next(0, (int)enState.Locked + 1);
            Code = passcode;
        }
        public void ChangeCode()
        {
            string userEnteredCode = default;
            do
            {
                Console.Write("Enter current password: ");
                userEnteredCode = Console.ReadLine();
                if (userEnteredCode == Code)
                {
                    Console.Write("Enter the new password: ");
                    Code = Console.ReadLine();
                    break;
                }
            }
            while (userEnteredCode != Code);
        }
    }
    enum enState { Open, Closed, Locked}
    enum Actions { Open, Close, Lock, Unlock}
}