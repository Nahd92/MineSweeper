using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    struct MineSweeper
    {
        private static Board board;
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
            do
            {
                Console.Write(prompt);
                var input = Console.ReadLine().Split(' ');
                var command = input[0].Trim();
                var row = int.Parse(input[1].Trim());
                var col = char.Parse(input[2].Trim());
                int cols = ((int)char.ToUpper(col)) - 65;

                if (command == "r".ToLower())
                {
                    return "r";
                }
                else if (command == "f".ToLower())
                {
                    return "f";
                }
                else
                {
                    Console.WriteLine("syntax error");
                }
            }
            while (true);
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

                var input = ReadCommand("> ");


            }
        }
    }
}

