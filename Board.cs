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
        private bool gameOver;
        private bool playerWon;
        // Konstruktor som initaliserar en ny spelplan.
        public Board(string[] args)
        {
            board = new Square[10, 10];
            flagCount = 0;
            sweepedCount = 0;
            gameOver = false;
            playerWon  = false; 


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
        public bool PlayerWon => playerWon;


        // Enbart läsbar egenskap som säger om spelaren har förlorat.
        public bool GameOver => gameOver;



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
            if (!(flagCount >= 25))
            {
                flagCount++;
                board[row, col].TryFlag();
            }
            return false;
        }


        public bool TryReveal(int row, int col)
        {
            if (IsValid(row, col) || !board[row, col].IsRevealed)
            {
                if ( Helper.BoobyTrapped(row, col) == true)
                {
                    board[row, col].TryReveal();
                    for(int i = 0; i < 10; i++)
                    {
                        for(int j = 0; j < 10; j++)
                        {
                            board[i,j].GameOver = true;
                        }

                    }
                    
                    gameOver = true;
                }
                else 
                if (board[row, col].TryReveal() && board[row, col].Symbol == (char)Square.GameSymbol.SweepedZeroCloseMine)
                {

                    if ((row + 1 < 10) && !board[row + 1, col].IsRevealed) TryReveal(row + 1, col);
                    if ((row + 1 < 10 && col + 1 < 10) && !board[row + 1, col + 1].IsRevealed) TryReveal(row + 1, col + 1);
                    if ((row + 1 < 10 && col - 1 >= 0) && !board[row + 1, col - 1].IsRevealed) TryReveal(row + 1, col - 1);
                    if ((col + 1 < 10) && !board[row, col + 1].IsRevealed) TryReveal(row, col + 1);
                    if ((col - 1 >= 0) && !board[row, col - 1].IsRevealed) TryReveal(row, col - 1);
                    if ((row - 1 >= 0 && col + 1 < 10) && !board[row - 1, col + 1].IsRevealed) TryReveal(row - 1, col + 1);
                    if ((row - 1 >= 0 && col - 1 >= 0) && !board[row - 1, col - 1].IsRevealed) TryReveal(row - 1, col - 1);
                    if ((row - 1 >= 0) && !board[row - 1, col].IsRevealed) TryReveal(row - 1, col);

                }
                playerWon = true;
                for(int i = 0; i < 10; i++)
                {
                    for(int j = 0; j < 10; j++)
                    {
                        if (board[i, j].IsRevealed == false && board[i,j].BoobyTrapped == false)
                        {
                            playerWon = false;
                        } 
                    }
                }
            }
            return false;
        }



        //Används inte för tillfället
        public void revealsquare(int row, int col)
        {
            if (IsValid(row, col) && !board[row, col].IsRevealed)
            {
                board[row, col].TryReveal();
                if ((row + 1 < 10) && !board[row + 1, col].IsRevealed && board[row + 1, col].BoobyTrapped) revealsquare(row + 1, col);
                if ((row + 1 < 10 && col + 1 < 10) && !board[row + 1, col + 1].IsRevealed && board[row + 1, col + 1].BoobyTrapped) revealsquare(row + 1, col + 1);
                if ((row + 1 < 10 && col - 1 >= 0) && !board[row + 1, col - 1].IsRevealed && board[row + 1, col - 1].BoobyTrapped) revealsquare(row + 1, col - 1);
                if ((col + 1 < 10) && !board[row, col + 1].IsRevealed && board[row, col + 1].BoobyTrapped) revealsquare(row, col + 1);
                if ((col - 1 >= 0) && !board[row, col - 1].IsRevealed && board[row, col - 1].BoobyTrapped) revealsquare(row, col - 1);
                if ((row - 1 >= 0 && col + 1 < 10) && !board[row - 1, col + 1].IsRevealed && board[row - 1, col + 1].BoobyTrapped) revealsquare(row - 1, col + 1);
                if ((row - 1 >= 0 && col - 1 >= 0) && !board[row - 1, col - 1].IsRevealed && board[row - 1, col - 1].BoobyTrapped) revealsquare(row - 1, col - 1);
                if ((row - 1 >= 0) && !board[row - 1, col].IsRevealed && !board[row - 1, col].BoobyTrapped) revealsquare(row - 1, col);
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
