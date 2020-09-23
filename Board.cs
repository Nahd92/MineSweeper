using System;

namespace MineSweeper
{
    public class Board
    {

        //Dom andra klasserna behöver inte känna till dessa variabler och arrays.
        private string[] header = { " ", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        private int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private string borderHorizontal = "   +--------------------";
        private string borderVertical = "|";
        private string[,] board = new string[10, 10];
        int[] row = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] col = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };


        public void DisplayBoard()
        {
            //Displayed the filled Array
            FillBoard();

            //Output the data
            for (int i = 0; i < header.Length; i++)
            {
                Console.Write(" " + header[i]);
            }
            Console.WriteLine();
            Console.Write(borderHorizontal);
            Console.WriteLine();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write(" " + numbers[i] + " " + borderVertical);
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(" " + board[i, j]);
                }
                Console.Write("\n");
            }
        }


        public void FillBoard()
        {
            //Fill the data 
            for (int i = 0; i < row.Length; i++)
            {
                for (int j = 0; j < col.Length; j++)
                {
                    board[row[i], col[j]] = "X";
                }
            }
        }
    }
}

