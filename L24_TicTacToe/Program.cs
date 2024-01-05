namespace L24_TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameBoard gameBoard = new GameBoard();
            Game game = new Game();
            game.Run(gameBoard);
        }
    }

    class GameBoard
    {
        public string[,] Board { get; set; }
        public bool IsFull { get; set; } = false;
        public GameBoard()
        {
            Board =  new string[,] { { "7", "8", "9"}, { "4", "5", "6"}, { "1", "2", "3"} };
        }
        public void DisplayBoard()
        {
            string separator;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Console.Write(Board[i, j]);
                    separator = j == 2 ?  "\n" : " | ";
                    Console.Write(separator);
                }
                if (i != 2) { Console.WriteLine("----------"); }
            }
        }

        public bool IsItFull()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i,j] != "X" && Board[i, j] != "O")
                    {
                        IsFull = false;
                        return IsFull;
                    }
                }
            }
            IsFull = true;
            return IsFull;
        }

        public string Winner()
        {
            string winner = "none";
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    //row victory
                    if (Board[0,j] == Board[1,j] && Board[1,j] == Board[2, j])
                    {
                        winner = Board[0, j];
                        return winner;
                    }
                    //column victory
                    if (Board[i,0] == Board[i,1] && Board[i, 1] == Board[i, 2])
                    {
                        winner = Board[i, 0];
                        return winner;
                    }
                    //diagonal victory1
                    if (Board[0,0] == Board[1,1] && Board[1,1] == Board[2, 2])
                    {
                        winner = Board[0,0];
                        return winner;
                    }
                    //diagonal victory2
                    if (Board[2,0] == Board[2,2] && Board[2,2] == Board[0, 2])
                    {
                        winner = Board[2, 0];
                        return winner;
                    }
                }
            }
            return winner;
        }
    }

    class Game
    {
        public int Turn { get; private set; } = 1;
        public string CurrentPlayer {  get; private set; }
        public void Run(GameBoard gameBoard)
        {
            Console.WriteLine("Select playing position with numpad on keyboard");
            do
            {
                gameBoard.DisplayBoard();
                if (Turn % 2 == 1)
                {
                    CurrentPlayer = "X";
                }
                else { CurrentPlayer = "O"; }
                Console.Write($"It's {CurrentPlayer}s turn, select position");
                string position = Console.ReadLine();
                bool found = false;
                for (int i = 0; i < gameBoard.Board.GetLength(0); i++)
                {
                    for (int j = 0; j < gameBoard.Board.GetLength(1); j++)
                    {
                        if (position == gameBoard.Board[i, j])
                        {
                            gameBoard.Board[i, j] = CurrentPlayer;
                            found = true;
                            break;
                        }
                    }

                    if (found) { break; }
                }
                if(gameBoard.Winner() != "none") { break; }
                Turn++;
            }
            while (!gameBoard.IsItFull());

            //EndGame
            switch (gameBoard.Winner())
            {
                case "none":
                    Console.WriteLine("The game is a draw.");
                    break;
                case "X":
                    Console.WriteLine("X is the Winner!");
                    break;
                case "O":
                    Console.WriteLine("O is the Winner!");
                    break;
            }
            gameBoard.DisplayBoard();
        }
    }
}