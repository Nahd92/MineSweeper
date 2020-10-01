using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MineSweeper
{
    struct Square
    {
        public enum GameSymbol
        {
            Flagged = 'F',
            NotSweeped = 'X',
            SweepedZeroCloseMine = '.'
        }
        public enum GameOverSymbol
        {
            ExplodedMine = 'M',
            FlaggedMine = 'ɯ',
            Mine = 'm',
            MisplacedFlag = 'Ⅎ'
        }

        private int closeMineCount; // Antal minor på intilliggande rutor
        private bool flagged, boobyTrapped, sweeped;
        private char symbol;
        public static int mineValue = -1;


        // Konstruktor som initierar en ny ruta på spelplanen.
        public Square(bool isBoobyTrapped)
        {
            closeMineCount = 0;
            flagged = false;
            this.boobyTrapped = isBoobyTrapped;
            sweeped = false;
            symbol = 'X';
            IsFlagged = false;
            IsRevealed = false;
        }

        // Enbart läsbar egenskap som säger om rutan är flaggad för tillfället.
        public bool IsFlagged { get; set; }

        // Enbart läsbar egenskap som säger om rutan är minerad.
        public bool BoobyTrapped
        {
            get
            {
                return boobyTrapped;
            }
            set { }

        }

        // Enbart läsbar egenskap som säger om rutan har blivit röjd. 
        public bool IsRevealed { get; set; }



        // Enbart läsbar egenskap som är symbolen som representerar rutan just nu 
        // om spelplanen skall ritas ut.
        public char Symbol
        {
            get
            {
                if (IsRevealed && boobyTrapped)
                {
                    return (char)GameOverSymbol.Mine;
                }

                else if (IsRevealed && !(IsFlagged && boobyTrapped))
                {
                    return (char)GameSymbol.SweepedZeroCloseMine;
                }
                else if (IsFlagged && !(boobyTrapped && IsRevealed))
                {
                    return (char)GameSymbol.Flagged;
                }
                else
                {
                    return (char)GameSymbol.NotSweeped;
                }
            }

        }

        // Enbart skrivbar egenskap som tilldelas true för alla rutor om spelaren 
        // röjer en minerad ruta 
        public bool GameOver
        {
            set
            {

            }
            // Stubbe
        }

        // Öka räknaren av minor på intilliggande rutor med 1.
        public void IncrementCloseMineCount() // Stubbe
        {
            closeMineCount++;
        }

        // Försök att flagga rutan. Returnerar false om ogiltigt drag, annars true.
        public bool TryFlag()
        {
            if (!IsRevealed && !boobyTrapped)
            {
                flagged = true;
            }
            return flagged;
        }

        // Försök röja rutan. Returnerar false om ogiltigt drag, annars true.
        public bool TryReveal() // Stubbe
        {
            return false;
        }

    }
}
