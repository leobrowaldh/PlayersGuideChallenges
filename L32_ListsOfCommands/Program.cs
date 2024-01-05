namespace L32_ListsOfCommands
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IRobotCommand?> commands = GetInput();
            Robot robot = new Robot() { Commands = commands };
            robot.Run();
        }

        private static List<IRobotCommand?> GetInput()
        {
            Console.WriteLine("Give your robot some commands.\n");
            Console.WriteLine("on => turn on");
            Console.WriteLine("off => turn off");
            Console.WriteLine("north => move north");
            Console.WriteLine("south => move south");
            Console.WriteLine("east => move east");
            Console.WriteLine("west => move west");
            Console.WriteLine("stop => no more commands");
            List<IRobotCommand?> commands = new List<IRobotCommand?>();
            string command;
            do
            {
                command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "on":
                        {
                            OnCommand onCommand = new OnCommand();
                            commands.Add(onCommand);
                            break;
                        }
                    case "off":
                        {
                            OffCommand offCommand = new OffCommand();
                            commands.Add(offCommand);
                            break;
                        }
                    case "north":
                        {
                            NorthCommand northCommand = new NorthCommand();
                            commands.Add(northCommand);
                            break;
                        }
                    case "south":
                        {
                            SouthCommand southCommand = new SouthCommand();
                            commands.Add(southCommand);
                            break;
                        }
                    case "east":
                        {
                            EastCommand eastCommand = new EastCommand();
                            commands.Add(eastCommand);
                            break;
                        }
                    case "west":
                        {
                            WestCommand westCommand = new WestCommand();
                            commands.Add(westCommand);
                            break;
                        }
                    default:
                        break;
                }
                
            }
            while (command != "stop");

            return commands;
        }
    }
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPowered { get; set; }
        public List<IRobotCommand?> Commands { get; init; } = new List<IRobotCommand?>();
        public void Run()
        {
            foreach (IRobotCommand? command in Commands)
            {
                command?.Run(this);
                Console.WriteLine($"[{X} {Y} {IsPowered}]");
            }
        }
    }
    public interface IRobotCommand
    {
        public void Run(Robot robot);
    }

    public class OnCommand : IRobotCommand
    {
        public void Run(Robot robot)
        {
            robot.IsPowered = true;
        }
    }
    public class OffCommand : IRobotCommand
    {
        public void Run(Robot robot)
        {
            robot.IsPowered = false;
        }
    }
    public class NorthCommand : IRobotCommand
    {
        public void Run(Robot robot)
        {
            if (robot.IsPowered) { robot.Y += 1; }
        }
    }
    public class SouthCommand : IRobotCommand
    {
        public void Run(Robot robot)
        {
            if (robot.IsPowered) { robot.Y -= 1; }
        }
    }
    public class EastCommand : IRobotCommand
    {
        public void Run(Robot robot)
        {
            if (robot.IsPowered) { robot.X += 1; }
        }
    }
    public class WestCommand : IRobotCommand
    {
        public void Run(Robot robot)
        {
            if (robot.IsPowered) { robot.X -= 1; }
        }
    }
}