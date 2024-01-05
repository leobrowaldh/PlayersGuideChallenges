using Helpers;

namespace L31_TheFounainOfObjects
{
    internal class Program //TODO> didnt end on victory conditions
    {
        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;
            //Generate the board:
            Console.WriteLine("Enter size of caverns: S for small, M for medium, L for large.");
            string size = Console.ReadLine().ToUpper();
            GameBoard gameBoard = new GameBoard(size);
            Fountain fountain = new Fountain("fountain", "this wont show", "You hear water dripping in the distance.");
            gameBoard = fountain.RandomizePosition(gameBoard);
            Entrance entrance = new Entrance("entrance", "this wont show", "You can see some light from the outside");
            gameBoard = entrance.RandomizePosition(gameBoard);
            gameBoard = GeneratePits(gameBoard);
            Player player = new Player(entrance.Row, entrance.Column);

            bool userInput = false;
            bool winCondition = false;
            bool looseCondition = false;
            do
            {
                PrintMenu();
                userInput = csConsoleInput.TryReadInt32("Enter your selection", 1, 5, out int selection);
                if (userInput)
                {
                    switch (selection)
                    {
                        case 1:
                            player.Move("north", gameBoard);
                            break;
                        case 2:
                            player.Move("south", gameBoard);
                            break;
                        case 3:
                            player.Move("east", gameBoard);
                            break;
                        case 4:
                            player.Move("west", gameBoard);
                            break;
                        case 5:
                            if (fountain.Row == player.Row  &&  fountain.Column == player.Column)
                            {
                                if (fountain.Enabled)
                                {
                                    Print.Color(ConsoleColor.Yellow, "Fountain is already enabled, now you have to get out!");
                                }
                                else
                                {
                                    fountain.Enabled = true;
                                    entrance.Enabled = true;
                                    Print.Color(ConsoleColor.Blue, "You have activated the fountain! Water runs again, now get out of here!");
                                }
                            }
                            else { Print.Color(ConsoleColor.Red, "The fountain is not here"); }
                            break;
                    }
                    if (gameBoard.Board[player.Row, player.Column] != null && gameBoard.Board[player.Row, player.Column].Name == "pit")
                        looseCondition = true;
                    winCondition = player.Row == entrance.Row && player.Column == entrance.Column && fountain.Enabled;
                }
            }
            while (!winCondition && !looseCondition);
            DateTime endTime = DateTime.Now;
            TimeSpan timeSpan = endTime - startTime;
            Console.WriteLine($"Total time in the caverns: {timeSpan.TotalMinutes}");
        }
        private static void PrintMenu()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Move North");
            Console.WriteLine("2. Move South");
            Console.WriteLine("3. Move East");
            Console.WriteLine("4. Move West");
            Console.WriteLine("5. Activate the fountain");
        }
        private static GameBoard GeneratePits(GameBoard gameBoard)
        {
            BoardObject pit = new BoardObject("pit", "You fell into a pit, what a pitty", "You feel a draft" +
                            "of air coming from somewhere near.");
            switch (gameBoard.Size)
            {
                case 4:
                    pit.RandomizePosition(gameBoard);
                    break;
                case 6:
                    pit.RandomizePosition(gameBoard);
                    pit.RandomizePosition(gameBoard);
                    break;
                case 8:
                    pit.RandomizePosition(gameBoard);
                    pit.RandomizePosition(gameBoard);
                    pit.RandomizePosition(gameBoard);
                    pit.RandomizePosition(gameBoard);
                    break;
            }
            return gameBoard;
        }
    }
    internal class GameBoard
    {
        public BoardObject[,] Board { get; set; }
        public int Size { get; set; }
        public GameBoard(string size)
        {
            if (size == "S")
            {
                Size = 4;
                Board = new BoardObject[4, 4]; 
            }
            if (size == "M") 
            {
                Size = 6;
                Board = new BoardObject[6, 6]; 
            }
            if (size == "L") 
            { 
                Size = 8;
                Board = new BoardObject[8, 8]; 
            }
        }
    }
    internal class BoardObject
    {
        public string Name { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public virtual string Message { get; }
        public virtual string ProximityMessage { get; }
        public BoardObject(string name, string message, string proximityMessage)
        {
            Name = name;
            Message = message;
            ProximityMessage = proximityMessage;
        }
        public GameBoard RandomizePosition(GameBoard gameBoard)
        {
            Random rnd = new Random();
            do
            {
                Row = rnd.Next(0, gameBoard.Board.GetLength(0));
                Column = rnd.Next(0, gameBoard.Board.GetLength(1));
            }
            while (gameBoard.Board[Row, Column] != null);
            gameBoard.Board[Row, Column] = this;
            return gameBoard;
        }
    }
    internal class Player
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Player(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public void Move(string direction, GameBoard gameBoard)
        {
            switch (direction)
            {
                case "north":
                    if (Row == 0)
                    {
                        Print.Color(ConsoleColor.Red, "You cannot move further north");
                        break;
                    }   
                    Row--;
                    Print.Color(ConsoleColor.Green, "You move north");
                    CheckSurroundings(gameBoard);
                    break;
                case "south":
                    if (Row == gameBoard.Board.GetLength(0) - 1)
                    {
                        Print.Color(ConsoleColor.Red, "You cannot move further south");
                        break;
                    }
                    Row++;
                    Print.Color(ConsoleColor.Green, "You move south");
                    CheckSurroundings(gameBoard);
                    break;
                case "east":
                    if (Column == gameBoard.Board.GetLength(1) - 1)
                    {
                        Print.Color(ConsoleColor.Red, "You cannot move further east");
                        break;
                    }
                    Column++;
                    Print.Color(ConsoleColor.Green, "You move east");
                    CheckSurroundings(gameBoard);
                    break;
                case "west":
                    if (Column == 0)
                    {
                        Print.Color(ConsoleColor.Red, "You cannot move further west");
                        break;
                    }
                    Column--;
                    Print.Color(ConsoleColor.Green, "You move west");
                    CheckSurroundings(gameBoard);
                    break;
            }
        }
        public void CheckSurroundings(GameBoard gameBoard)
        {
            if (gameBoard.Board[Row, Column] is not null)
            {
                Console.WriteLine(gameBoard.Board[Row, Column].Message); 
            }
            //we need Math.Min and Math.Max to make sure we dont get out of the Board limits
            for (int row = Math.Max(0, Row - 1); row <= Math.Min(gameBoard.Board.GetLength(0) - 1, Row + 1); row++)
            {
                for (int column = Math.Max(0, Column - 1); column <= Math.Min(gameBoard.Board.GetLength(1) - 1, Column + 1); column++)
                {
                    if (!(Row == row && Column == column) && gameBoard.Board[row, column] != null)
                    {
                        Console.WriteLine(gameBoard.Board[row, column].ProximityMessage);
                    }
                }
            }
        }
    }
    internal class Fountain : BoardObject
    {
        public bool Enabled { get; set; } = false;
        public override string Message
        {
            get 
            {
                return Enabled ? "you hear the rushing waters of the Fountain of Objects, it has been activated!" :
                    "You hear water dripping, the Fountain of Objects is here in this room!";
            }
        }
        public Fountain(string name, string message, string proximityMessage) : base(name, message, proximityMessage) { }
    }
    internal class Entrance : BoardObject
    {
        public bool Enabled { get; set; } = false;
        public override string Message
        {
            get
            {
                return Enabled ? "You can see the outside, you made it out, Victory is yours!" :
                    "You are at the entrance of the cave";
            }
        }
        public Entrance(string name, string message, string proximityMessage) : base(name, message, proximityMessage) { }
    }
    public static class Print
    {
        public static void Color(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}