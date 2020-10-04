using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    struct MineSweeper
    {
        private Board board;
        private bool quit;
        private Square square;

        // Konstruktor som initierare ett nytt spel med en slumpmässig spelplan.

        public MineSweeper(string[] args)
        {
            board = new Board(args);
            quit = false;
            square = new Square(isBoobyTrapped: true);

        }

        // Läs ett nytt kommando från användaren med giltig syntax och 
        // ett känt kommandotecken.
        static private string ReadCommand(string prompt) // Stubbe
        {
            Console.Write(prompt);
            string input = Console.ReadLine();


            return input;
        }

        // Kör spelet efter initering. Metoden returnerar när spelet tar 
        // slut genom att något av följande händer:
        // - Spelaren avslutade spelet med kommandot 'q'.
        // - Spelaren förlorade spelet genom att röja en minerad ruta. 
        // - Spelaren vann spelet genom att alla ej minerade rutor är röjda.
        public void Run() // Stubbe
        {
            Console.Clear();
            Console.WriteLine();
            board.Print();

            while (!(quit || board.PlayerWon || board.GameOver))
            {
                // Skriv klart spelloopen här

                // Skriv klart spelloopen här

                Console.WriteLine();

                Console.Write("f/r? : ");
                string input = Console.ReadLine();
                char inted = char.Parse(input);


                Console.Write("row: ");
                string row = Console.ReadLine();
                int rows = int.Parse(row);

                Console.Write("col: ");
                string column = Console.ReadLine();
                int col = int.Parse(column);


                if (inted == 'f')
                {
                    board.TryFlag(rows, col);
                    board.Print();
                }
                else if (inted == 'r')
                {
                    board.TryReveal(rows, col, 0);
                    board.Print();
                }
            }
        }
    }
}

