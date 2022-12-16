using System;

namespace TicTacToe
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
        static int player = 1;
        static int choice;
        static int flag = 0;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn");
                }
                else
                {
                    Console.WriteLine("Player 1's turn");
                }
                Console.WriteLine("\n");
                Board();
                choice = int.Parse(Console.ReadLine());

                // checking if the cell is not already marked
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry the cell is already marked with " + arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 seconds board is loading again.....");
                    Console.ReadKey();
                }
                flag = CheckWin();
            } while (flag != 1 && flag != -1); 

            Console.Clear();
            Board();

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Draw");
            }

            Console.ReadLine();
        }

        
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[0], arr[1], arr[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[3], arr[4], arr[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[6], arr[7], arr[8]);
            Console.WriteLine("     |     |      ");
        }

        
        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
            if (arr[0] == arr[1] && arr[1] == arr[2])
            {
                return 1;
            }
            return 0;

            #endregion
        }
    }
}