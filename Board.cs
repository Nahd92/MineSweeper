using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    // Typ för spelplanen i minröj.
    struct Board
    {
        Square[,] board;
        private int flagCount, sweepedCount, numberOfMines;
        Square square;


        // Konstruktor som initaliserar en ny spelplan.
        public Board(string[] args) // Stubbe
        {
            board = new Square[10, 10];
            flagCount = 0;
            sweepedCount = 0;
            numberOfMines = 0;
            square = new Square(isBoobyTrapped: true);
            Helper.Initialize(args); //körs en gång

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = new Square(isBoobyTrapped: Helper.BoobyTrapped(row, col));
                }
            }
        }

        // Enbart läsbar egenskap som säger som spelaren har vunnit spelet.
        public bool PlayerWon => false; // Stubbe

        // Enbart läsbar egenskap som säger om spelaren har förlorat.
        public bool GameOver => false; // Stubbe


        // Försök röja en ruta. Returnerar false om ogiltigt drag, annars true.
        public bool TryReveal(int row, int col) // Stubbe
        {
            if (!board[row, col].IsRevealed && row >= 0 && row < 10 && col >= 0 && col < 10)
            {
                return board[row, col].IsRevealed = true;
            }
            return false;
        }


        public bool IsMine(int row, int col)
        {
            if (board[row, col].IsRevealed && board[col, row].BoobyTrapped)
            {
                return board[row, col].IsMine = true;
            }
            return false;
        }



        // Försök flagga en ruta. Returnerar false om ogiltigt drag, annars true.
        public bool TryFlag(int row, int col) // Stubbe
        {
            if (GameOver) return false;
            if (!(board[row, col].IsFlagged && !board[row, col].IsRevealed))
            {
                board[row, col].IsFlagged = true;

            }
            return false;
        }
        // Skriv ut spelplanen till konsolen.
        public void Print() // Stubbe
        {
            //Fill the data 
            Console.WriteLine("    A B C D E F G H I J ");
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