namespace TicTacToeGame
{
    internal class Program
    {
        static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }; 
        static int currentPlayer = 1; 
        static bool gameEnded = false;
        static int drawMode = 0;

        static void Main(string[] args)
        {
            while (!gameEnded)
            {
                Console.Clear();
                DisplayBoard();
                PlayerMove();
                CheckGameStatus();
                SwapPlayer();
            }

            Console.Clear();
            DisplayBoard();
            if (gameEnded && drawMode == 0)
            {
                int winningPlayer = (currentPlayer % 2) + 1;
                Console.WriteLine($"Player {winningPlayer} wins!");
            }
            else 
            {
                Console.WriteLine("Its a draw");
            }
            
        }

        static void DisplayBoard()
        {
            Console.WriteLine($"     |     |      \n" +
                   $"  {board[0]}  |  {board[1]}  |  {board[2]}  \n" +
                   $"_____|_____|_____ \n" +
                   $"     |     |      \n" +
                   $"  {board[3]}  |  {board[4]}  |  {board[5]}  \n" +
                   $"_____|_____|_____ \n" +
                   $"     |     |      \n" +
                   $"  {board[6]}  |  {board[7]}  |  {board[8]}  \n" +
                   $"     |     |      ");
        }

        static void PlayerMove()
        {
            int choice;
            bool validMove = false;

            while (!validMove)
            {
                Console.WriteLine($"Player {currentPlayer}, choose your position (1-9): ");

                string input = Console.ReadLine();
                bool isANumber = int.TryParse(input, out choice);

                if (isANumber && choice >= 1 && choice <= 9)
                {
                    if (board[choice - 1] == ' ')
                    {
                        if (currentPlayer == 1)
                        {
                            board[choice - 1] = 'X';
                        }
                        else
                        {
                            board[choice - 1] = 'O';
                        }
                        validMove = true;
                    }
                    else
                    {
                        Console.WriteLine("That position is already taken. Please choose an empty position.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 9.");
                }
            }
        }

        static void SwapPlayer()
        {
            currentPlayer = 3 - currentPlayer; // Swap between 1 and 2
        }

        static void CheckGameStatus()
        {
            bool anyEmptySpot = false;

            foreach (char c in board)
            {
                if (c == ' ')
                {
                    anyEmptySpot = true;
                    break;
                }
            }
            if (!anyEmptySpot)
            {
                // No empty region and no win
                gameEnded = true;
                drawMode++;
                return;
            }

            char[] wins = { 'X', 'O' };

            foreach (char playerChar in wins)
            {
                if ((board[0] == playerChar && board[1] == playerChar && board[2] == playerChar) ||
                    (board[3] == playerChar && board[4] == playerChar && board[5] == playerChar) ||
                    (board[6] == playerChar && board[7] == playerChar && board[8] == playerChar) ||
                    (board[0] == playerChar && board[3] == playerChar && board[6] == playerChar) ||
                    (board[1] == playerChar && board[4] == playerChar && board[7] == playerChar) ||
                    (board[2] == playerChar && board[5] == playerChar && board[8] == playerChar) ||
                    (board[0] == playerChar && board[4] == playerChar && board[8] == playerChar) ||
                    (board[2] == playerChar && board[4] == playerChar && board[6] == playerChar))
                {
                    gameEnded = true;
                    return;
                }
            }

            gameEnded = false;
        }
    }
}

