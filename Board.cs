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



        // Konstruktor som initaliserar en ny spelplan.
        public Board(string[] args) // Stubbe
        {
            board = new Square[10, 10];
            flagCount = 0;
            sweepedCount = 0;
            numberOfMines = 0;
            GameOver = false;


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
        public bool GameOver { get; set; }


        //Kontrollerar om inputet är valid
        private bool IsValid(int row, int col)
        {
            return row >= 0 && row < 10 && col >= 0 && col < 10;
        }


        private int CalculateNearbyMines(int row, int col)
        {
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


        public bool TryReveal(int row, int col) // Stubbe
        {
            if (!board[row, col].IsRevealed)
            {
                return board[row, col].IsRevealed = true;
            }
            return false;
        }
        //Ska visa samtliga tomma platser (Om de finns några) nära input
        public void RevealBoard(int row, int col)
        {
            if (IsValid(row, col))
            {
                if (board[row, col].IsRevealed || GameOver) return;
                if (board[row, col].BoobyTrapped)
                {
                    board[row, col].IsRevealed = true;
                    GameOver = true;
                    return;
                }
                else
                {
                    board[row, col].IsRevealed = true;
                    if ((row + 1 < 10) && !board[row + 1, col].IsRevealed) RevealBoard(row + 1, col);
                    if ((row + 1 < 10 && col + 1 < 10) && !board[row + 1, col + 1].IsRevealed) RevealBoard(row + 1, col + 1);
                    if ((row + 1 < 10 && col - 1 >= 0) && !board[row + 1, col - 1].IsRevealed) RevealBoard(row + 1, col - 1);
                    if ((col + 1 < 10) && !board[row, col + 1].IsRevealed) RevealBoard(row, col + 1);
                    if ((col - 1 >= 0) && !board[row, col - 1].IsRevealed) RevealBoard(row, col - 1);
                    if ((row - 1 >= 0 && col + 1 < 10) && !board[row - 1, col + 1].IsRevealed) RevealBoard(row - 1, col + 1);
                    if ((row - 1 >= 0 && col - 1 >= 0) && !board[row - 1, col - 1].IsRevealed) RevealBoard(row - 1, col - 1);
                    if ((row - 1 >= 0) && !board[row - 1, col].IsRevealed) RevealBoard(row - 1, col);
                }
            }
            else return;
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