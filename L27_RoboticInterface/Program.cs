namespace L27_RoboticInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRobotCommand?[] commands = GetInput();
            Robot robot = new Robot() { Commands = commands };
            robot.Run();
        }

        private static IRobotCommand?[] GetInput()
        {
            Console.WriteLine("Give your robot 3 commands.\n");
            Console.WriteLine("on => turn on");
            Console.WriteLine("off => turn off");
            Console.WriteLine("north => move north");
            Console.WriteLine("south => move south");
            Console.WriteLine("east => move east");
            Console.WriteLine("west => move west");
            IRobotCommand?[] commands = new IRobotCommand?[3];
            for (int i = 0; i < 3; i++)
            {
                string command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "on":
                        {
                            OnCommand onCommand = new OnCommand();
                            commands[i] = onCommand;
                            break;
                        }
                    case "off":
                        {
                            OffCommand offCommand = new OffCommand();
                            commands[i] = offCommand;
                            break;
                        }
                    case "north":
                        {
                            NorthCommand northCommand = new NorthCommand();
                            commands[i] = northCommand;
                            break;
                        }
                    case "south":
                        {
                            SouthCommand southCommand = new SouthCommand();
                            commands[i] = southCommand;
                            break;
                        }
                    case "east":
                        {
                            EastCommand eastCommand = new EastCommand();
                            commands[i] = eastCommand;
                            break;
                        }
                    case "west":
                        {
                            WestCommand westCommand = new WestCommand();
                            commands[i] = westCommand;
                            break;
                        }
                }
            }

            return commands;
        }
    }
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPowered { get; set; }
        public IRobotCommand?[] Commands { get; init; } = new IRobotCommand?[3];
        public void Run()
        {
            foreach (IRobotCommand? command in Commands)
            {
                command?.Run(this);
                Console.WriteLine($"[{X} {Y} {IsPowered}]");
            }
        }
    }
    public interface  IRobotCommand
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