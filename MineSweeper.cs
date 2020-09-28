using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    // Typ för minröjspelet. 
    struct MineSweeper
    {
        private Board board;
        private bool quit;

        // Konstruktor som initierare ett nytt spel med en slumpmässig spelplan.
        public MineSweeper(string[] args)
        {
            board = new Board(args);
            quit = false;

        }

        // Läs ett nytt kommando från användaren med giltig syntax och 
        // ett känt kommandotecken.
        static private string ReadCommand() // Stubbe
        {
            return null;
        }

        // Kör spelet efter initering. Metoden returnerar när spelet tar 
        // slut genom att något av följande händer:
        // - Spelaren avslutade spelet med kommandot 'q'.
        // - Spelaren förlorade spelet genom att röja en minerad ruta. 
        // - Spelaren vann spelet genom att alla ej minerade rutor är röjda.
        public void Run() // Stubbe
        {
            while (!(quit || board.PlayerWon || board.GameOver))
            {
                // Skriv klart spelloopen här
                Console.WriteLine("Skriv färdigt spelet!");
                board.Print();
                break;
            }
        }
    }
}