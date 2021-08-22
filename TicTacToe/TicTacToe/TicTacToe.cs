using System;


namespace TicTacToe
{
    public class TicTacToe
    {

        public static bool isFirstPlayersTurn = true;
        public static Board board;
        public static int turnNumber = 0;

        static void Main()
        {
            while (true)
            {
                ClearBoard();
                Play();
            }

            void ClearBoard()
            {
                board = new Board();
                turnNumber = 0;
                board.ShowBoard();
            }

            void Play()
            {
                while(true)
                {
                   
                    board.ChooseRowThenCol();
                    board.ShowBoard();
                    if(CheckForWinner())
                    {
                        break;
                    }
                    else
                    {
                        isFirstPlayersTurn = !isFirstPlayersTurn;
                        turnNumber++;
                    }

                    if(turnNumber >= 9)
                    {
                        Console.WriteLine("It's a draw!");
                        return; 
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to play again!");
                Console.ReadKey(true);

            }
        }

        static bool CheckForWinner()
        {

            if(Horizontal() || Vertical() || Diagonal())
            {
                return true;
            }
            else
            {
                return false; 
            }

            bool Horizontal()
            {
                for(int i = 0; i < board.row.Length; i++)
                {
                    bool winner = true;
                    bool isX = false;
                    int[] col = board.row[i].col;
                    int checkHorizontal = col[0];
                    switch (checkHorizontal)
                    {
                        case 0:
                            continue;
                        case 1:
                            isX = true;
                            break;
                        case 2:
                            isX = false;
                            break; 

                    }

                    for(int j = 0; j < col.Length; j++)
                    {
                        if(col[j] != checkHorizontal)
                        {
                            winner = false;
                            break;
                        }
                    }
                    if (winner)
                    {
                        ShowWinner(isX);
                        return true;
                    }
                }

                return false; 
            }

            bool Vertical()
            {
                bool winner = true;
                bool isX = false;
                int[] col = board.row[0].col;

                for(int i = 0; i < 3; i++)
                {
                    winner = true;
                    int checkVertical = col[i];
                    switch(checkVertical)
                    {
                        case 0:
                            continue;
                        case 1:
                            isX = true;
                            break;
                        case 2:
                            isX = false;
                            break;
                    }

                    for(int j = 0; j < 3; j++)
                    {
                        if(board.row[j].col[i] != checkVertical)
                        {
                            winner = false;
                            break; 
                        }
                    }
                    if (winner)
                    {
                        ShowWinner(isX);
                        return true; 
                    }

                }

                return false;


            }

            bool Diagonal()
            {
                bool winner = true;
                bool isX = false;
                int firstCol = board.row[0].col[0];

                switch (firstCol)
                {
                    case 0:
                        winner = false;
                        break;
                    case 1:
                        isX = true;
                        break;
                    case 2:
                        isX = false;
                        break;
                }
                for (int i = 0; i < 3; ++i)
                {
                    if (board.row[i].col[i] != firstCol)
                    {
                        winner = false;
                        break;
                    }
                }
                if (winner)
                {
                    ShowWinner(isX);
                    return true;
                }

                winner = true;

                int thirdCol = board.row[0].col[2];

                switch (thirdCol)
                {
                    case 0:
                        winner = false;
                        break;
                    case 1:
                        isX = true;
                        break;
                    case 2:
                        isX = false;
                        break;
                }
                for (int i = 0; i < 3; ++i)
                {
                    if (board.row[i].col[2 - i] != thirdCol)
                    {
                        winner = false;
                        break;
                    }
                }
                if (winner)
                {
                    ShowWinner(isX);
                    return true;
                }
                return false;

            }

            void ShowWinner(bool isX)
            {
                char winningPlayer;

                if(isX)
                {
                    winningPlayer = 'X';
                } else
                {
                    winningPlayer = 'X';
                }

                Console.WriteLine(winningPlayer + " Wins!");

            }

        }


    }


    public class Board
    {
        public Row[] row;

        public Board()
        {
            row = new Row[3];
            for (int i = 0; i < 3; i++)
            {
                row[i] = new Row();
            }
        }

        public void ShowBoard()
        {
            for (int i = 0; i < row.Length; i++)
            {
                row[i].DisplayContent();
            }
        }
        public void ChooseRowThenCol()
        {
            string userInput = "";
            int rowNum = 0;

            Console.WriteLine("Choose a row (1 - 3): ");
            userInput = Console.ReadLine();
            if(int.TryParse(userInput, out rowNum))
            {
                if(rowNum > 3 || rowNum < 1)
                {
                    Console.WriteLine("Invalid input. Please try again");
                    ChooseRowThenCol();
                    return;
                }

                row[rowNum - 1].ChooseCol(TicTacToe.isFirstPlayersTurn);
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again");
                ChooseRowThenCol();
                return;
            }

        }
    }

    public class Row
    {
        public int[] col;

        public void ChooseCol(bool isX)
        {

            string userInput;
            int colNum;

            Console.WriteLine("Choose a column (1 -3): ");
            userInput = Console.ReadLine();
            if (int.TryParse(userInput, out colNum))
            {
                if (colNum > 3 || colNum < 1)
                {
                    Console.WriteLine("Invalid input. Please try again");
                    ChooseCol(isX);
                    return;

                }
                if (col[colNum - 1] != 0)
                {
                    Console.WriteLine("Invalid input. Please try again");
                    TicTacToe.board.ChooseRowThenCol();
                    return;
                }

                if (isX)
                {
                    col[colNum - 1] = 1;
                } else
                {
                    col[colNum - 1] = 2;
                }
            }

            else
            {

                Console.WriteLine("Invalid input. Please try again");
                ChooseCol(isX);


            }

        }

        public void DisplayContent()
        {
            string line = "";

            for (int i = 0; i < col.Length; i++)
            {
                if (col[i] == 0)
                {
                    line += "-";
                } else if (col[i] == 1)
                {
                    line += "X";
                }
                else if (col[i] == 2)
                {
                    line += "O";
                }
            }

            Console.WriteLine(line);
        }

        public Row()
        {
            col = new int[3];
        }




    }



}
