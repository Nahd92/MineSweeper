using System;

namespace MineSweeper
{
    public class Board
    {


        private void DrawBoard()
        {
            string[] header = { " ", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string borderHorizontal = "   +--------------------";
            string borderVertical = "|";

            string[,] board = new string[10, 10] {
                    {"X", "X", "X", "X", "X", "X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X", "X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X", "X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X", "X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X", "X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X", "X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X", "X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X", "X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X", "X", "X", "X", "X", "X"},
                    {"X", "X", "X", "X", "X", "X", "X", "X", "X", "X"},
            };

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
                    Console.Write(" " + "{0}", board[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
