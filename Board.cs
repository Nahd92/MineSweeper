using System;

namespace MineSweeper
{
    public enum Col
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4,
        F = 5,
        G = 6,
        H = 7,
        I = 8,
        J = 9
    }


    public struct Board
    {

        //Dom andra klasserna behöver inte känna till dessa variabler och arrays.
        static readonly string[] header = { " ", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        static private readonly int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static private readonly string borderHorizontal = "   +--------------------";
        static private readonly string borderVertical = "|";
        static private string[,] board = new string[10, 10];
        static private int[] row = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static private Col[] col = new Col[10] { Col.A, Col.B, Col.C, Col.D, Col.E, Col.F, Col.G, Col.H, Col.I, Col.J };
        static string crossSymbol = "X";


        public static void DisplayBoard()
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
                Console.Write(" " + numbers[i] + " " + borderVertical);  // Denna skapar | och numrena i vertikal riktning bredvid X 
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(" " + board[i, j]);
                }
                Console.Write("\n");
            }
        }
        public static void FillBoard()
        {
            //Fill the data 
            for (int i = 0; i < row.Length; i++)
            {
                for (int j = 0; j < col.Length; j++)
                {
                    board[row[i], (int)col[j]] = crossSymbol;
                }
            }
        }
    }
}

