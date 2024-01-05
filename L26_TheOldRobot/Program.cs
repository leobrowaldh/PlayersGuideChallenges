namespace L26_TheOldRobot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RobotCommand?[] commands = GetInput();
            Robot robot = new Robot() { Commands = commands };
            robot.Run();
        }

        private static RobotCommand?[] GetInput()
        {
            Console.WriteLine("Give your robot 3 commands.\n");
            Console.WriteLine("on => turn on");
            Console.WriteLine("off => turn off");
            Console.WriteLine("north => move north");
            Console.WriteLine("south => move south");
            Console.WriteLine("east => move east");
            Console.WriteLine("west => move west");
            RobotCommand?[] commands = new RobotCommand?[3];
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
        public RobotCommand?[] Commands { get; init; } = new RobotCommand?[3];
        public void Run()
        {
            foreach (RobotCommand? command in Commands)
            {
                command?.Run(this);
                Console.WriteLine($"[{X} {Y} {IsPowered}]");
            }
        }
    }
    public abstract class RobotCommand
    {
        public abstract void Run(Robot robot);
    }

    public class OnCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            robot.IsPowered = true;
        }
    }
    public class OffCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            robot.IsPowered = false;
        }
    }
    public class NorthCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered) { robot.Y += 1; }
        }
    }
    public class SouthCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered) { robot.Y -= 1; }
        }
    }
    public class EastCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered) { robot.X += 1; }
        }
    }
    public class WestCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered) { robot.X -= 1; }
        }
    }
}