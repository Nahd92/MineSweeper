using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace MineSweeper
{
    struct Board
    {
        Square[,] board;
        private int flagCount, sweepedCount;

        // Konstruktor som initaliserar en ny spelplan.
        public Board(string[] args)
        {
            board = new Square[10, 10];
            flagCount = 0;
            sweepedCount = 0;



            Helper.Initialize(args);

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = new Square(Helper.BoobyTrapped(row, col));
                }
            }
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    int nearbyMine = CalculateNearbyMines(row, col);

                    for (int i = 0; i < nearbyMine; i++)
                    {
                        board[row, col].IncrementCloseMineCount();
                    }
                }
            }
        }


        // Enbart läsbar egenskap som säger som spelaren har vunnit spelet.
        public bool PlayerWon => false;


        // Enbart läsbar egenskap som säger om spelaren har förlorat.
        public bool GameOver => false;



        //Kontrollerar om inputet är valid
        private bool IsValid(int row, int col)
        {
            return row >= 0 && row < 10 && col >= 0 && col < 10;
        }


        private int CalculateNearbyMines(int row, int col)
        {
            int numberOfMines = 0;
            if (board[row, col].BoobyTrapped) return Square.mineValue;

            if (row - 1 >= 0 && board[row - 1, col].BoobyTrapped) numberOfMines++;
            if (row - 1 >= 0 && col - 1 >= 0 && board[row - 1, col - 1].BoobyTrapped) numberOfMines++;
            if (row - 1 >= 0 && col + 1 < 10 && board[row - 1, col + 1].BoobyTrapped) numberOfMines++;
            if (col - 1 >= 0 && board[row, col - 1].BoobyTrapped) numberOfMines++;
            if (col + 1 < 10 && board[row, col + 1].BoobyTrapped) numberOfMines++;
            if (row + 1 < 10 && col - 1 >= 0 && board[row + 1, col - 1].BoobyTrapped) numberOfMines++;
            if (row + 1 < 10 && board[row + 1, col].BoobyTrapped) numberOfMines++;
            if (row + 1 < 10 && col + 1 < 10 && board[row + 1, col + 1].BoobyTrapped) numberOfMines++;
            return numberOfMines;
        }




        // Försök flagga en ruta. Returnerar false om ogiltigt drag, annars true.
        public bool TryFlag(int row, int col)
        {
            if (!board[row, col].IsFlagged && !(flagCount >= 20))
            {
                flagCount++;
                board[row, col].TryFlag();
            }
            return false;
        }

        public bool TryReveal(int row, int col)
        {
            if (!board[row, col].IsRevealed)
            {
                if (board[row, col].TryReveal() && board[row, col].Symbol == (char)Square.GameSymbol.SweepedZeroCloseMine)
                {
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            if (IsValid(row + i, col + j) && (!board[row + i, col + j].IsRevealed))
                                TryReveal(row + i, col + j);
                        }
                    }
                    sweepedCount++;
                }
            }
            return false;
        }
    }


    // Skriv ut spelplanen till konsolen.
    public void Print() // Stubbe
    {
        //Fill the data 
        Console.WriteLine("     A B C D E F G H I J ");
        Console.WriteLine("   +--------------------");
        for (int row = 0; row < 10; row++)
        {
            Console.Write($" {row} |");
            for (int col = 0; col < 10; col++)
            {
                Console.Write(" " + board[row, col].Symbol);
            }
            Console.WriteLine();
        }
    }
}
}
