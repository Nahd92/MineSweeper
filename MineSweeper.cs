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
        static private string ReadCommand(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!(input.Length == 1 || input.Length == 4))
                {
                    Console.WriteLine("syntax error");
                    continue;
                }

                if (!Regex.IsMatch(input[0].ToString(), @"[a-ö]"))
                {
                    Console.WriteLine("syntax error");
                    continue;
                }

                if (input.Length == 1)
                {
                    if (!(input == "q"))
                    {
                        Console.WriteLine("unknown command");
                        continue;
                    }
                    else
                    {
                        return input;
                    }
                }

                if (!(input[1].ToString() == " "))
                {
                    Console.WriteLine("syntax error");
                    continue;
                }
                if (!Char.IsLetter(input[2]) || !Regex.IsMatch(input[2].ToString(), @"[a-j]"))
                {
                    Console.WriteLine("syntax error");
                    continue;
                }
                if (!Char.IsNumber(input[3]) || !Regex.IsMatch(input[3].ToString(), @"[0-9]"))
                {
                    Console.WriteLine("syntax error");
                    continue;
                }

                if (input.Length == 4)
                {

                    if (!(input.StartsWith('f') || input.StartsWith('r')))
                    {
                        Console.WriteLine("unkown command");
                        continue;
                    }
                    else
                    {
                        return input;
                    }
                }
            }
        }

        // Kör spelet efter initering. Metoden returnerar när spelet tar 
        // slut genom att något av följande händer:
        // - Spelaren avslutade spelet med kommandot 'q'.
        // - Spelaren förlorade spelet genom att röja en minerad ruta. 
        // - Spelaren vann spelet genom att alla ej minerade rutor är röjda.
        public void Run() // Stubbe
        {
            Console.WriteLine();
            Console.Clear();
            board.Print();

            while (!(quit || board.PlayerWon || board.GameOver))
            {
                Console.WriteLine();


                string input = ReadCommand("> ");
                if (input.Length == 1)
                {
                    quit = true;
                    break;
                }

                var command = input[0].ToString();
                var cols = char.Parse(input[2].ToString());
                int col = ((int)char.ToUpper(cols)) - 65;
                var row = int.Parse(input[3].ToString());


                if (command == "r")
                {
                    board.TryReveal(row, col);
                    board.Print();
                    continue;
                }
                if (command == "f")
                {
                    board.TryFlag(row, col);
                    board.Print();
                    continue;
                }

            }
        }
    }
}

