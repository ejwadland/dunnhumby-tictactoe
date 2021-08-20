using System;

namespace TicTacToe
{
    class Program
    {

        static void Main(string[] args)
        {
            char[,] board = new char[3, 3];
            char player = 'X';
            bool gameEnd = false;
            int playerMoves = 0;
            int row;
            int col;

            Console.WriteLine("Welcome to Tic-Tac-Toe!");

            // Initialise the board
            Initialise(board);

            while (gameEnd == false)
            {

                Console.Clear();

                Print(board);
                // Get user row input

                Console.Write("Please enter row number (0-2): ");
                // ADD TYPE TEST HERE
                row = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please enter column number (0-2): ");
                // ADD TYPE TEST HERE
                col = Convert.ToInt32(Console.ReadLine());



                // Checking Win
                if (player == board[0, 0] && player == board[0, 1] && player == board[0, 2])
                    {
                        Console.WriteLine(player + " wins!");
                        gameEnd = true;
                    }

                    playerMoves++;

                    if (playerMoves == 9)
                    {
                        Console.WriteLine("It's a draw!");
                        gameEnd = true;

                    }

                player = ChangePlayerTurn(player);

            }

                // Initialise Board Method

                static void Initialise(char[,] board)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        for (int col = 0; col < 3; col++)
                        {
                            board[row, col] = '-';
                        }

                    }

                }
                // Print Out Board Method

                static void Print(char[,] board)
                {

                    for (int row = 0; row < 3; row++)
                    {
                        for (int col = 0; col < 3; col++)
                        {
                            Console.Write(board[row, col]);
                        }
                        Console.WriteLine();

                    }

                }

                static char ChangePlayerTurn(char currentPlayer)
                {
                    if (currentPlayer == 'X')
                    {
                        return 'O';
                    }
                    else
                    {
                        return 'X';
                    }
                }

             bool CheckPosition(char[,] board)
            {
                if (board[row, col] == 'X' || board[row,col] == 'O')
                {
                    return false;

                } else
                {
                    return true;
                }

            }



            }
        }
    

    
}
