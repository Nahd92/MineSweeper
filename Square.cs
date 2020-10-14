using System;


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


        // Konstruktor som initierar en ny ruta på spelplanen.
        public Square(bool isBoobyTrapped)
        {
            closeMineCount = 0;
            flagged = false;
            this.boobyTrapped = isBoobyTrapped;
            sweeped = false;
            symbol = (char)GameSymbol.NotSweeped;
        }


        // Enbart läsbar egenskap som säger om rutan är flaggad för tillfället.
        public int CloseMineCount
        {
            get { return closeMineCount; }
            set { closeMineCount = value; }
        }
        // Enbart läsbar egenskap som säger om rutan är flaggad för tillfället.
        public bool IsFlagged => flagged;

        // Enbart läsbar egenskap som säger om rutan är minerad.
        public bool BoobyTrapped => boobyTrapped;


        // Enbart läsbar egenskap som säger om rutan har blivit röjd. 
        public bool IsRevealed => sweeped;


        // Enbart läsbar egenskap som är symbolen som representerar rutan just nu 
        // om spelplanen skall ritas ut.
        public char Symbol => symbol;
        // Enbart skrivbar egenskap som tilldelas true för alla rutor om spelaren 
        // röjer en minerad ruta 
        public bool GameOver
        {
            set
            {
                if (value)
                {
                    if (boobyTrapped)
                    {
                        symbol = (char)GameOverSymbol.Mine;
                    }
                    if (sweeped && boobyTrapped)
                    {
                        symbol = (char)GameOverSymbol.ExplodedMine;
                    }
                    if (flagged && !boobyTrapped)
                    {
                        symbol = (char)GameOverSymbol.MisplacedFlag;
                        Console.OutputEncoding = System.Text.Encoding.UTF8;
                    }
                    if (flagged && boobyTrapped && !sweeped)
                    {
                        symbol = (char)GameOverSymbol.FlaggedMine;
                        Console.OutputEncoding = System.Text.Encoding.UTF8;
                    }
                }
            }
        }


        // Öka räknaren av minor på intilliggande rutor med 1.
        public void IncrementCloseMineCount() // Stubbe
        {
            closeMineCount++;
        }


        // Försök att flagga rutan. Returnerar false om ogiltigt drag, annars true.
        public bool TryFlag()
        {
            if (IsRevealed)
            {
                Console.WriteLine("not allowed");
                return false;
            }
            else
            {
                if (flagged)
                {
                    flagged = false;
                    symbol = (char)GameSymbol.NotSweeped;

                }
                else
                {
                    flagged = true;
                    symbol = (char)GameSymbol.Flagged;
                }

                return true;

            }
        }


        // Försök röja rutan. Returnerar false om ogiltigt drag, annars true.
        public bool TryReveal()
        {
            if (!sweeped && !flagged)
            {
                sweeped = true;
                if (closeMineCount == 0)
                {
                    symbol = (char)GameSymbol.SweepedZeroCloseMine;
                }
                else
                {
                    symbol = char.Parse(closeMineCount.ToString());
                }
                return true;
            }
            else
            {
                Console.WriteLine("not allowed");
                return false;
            }
        }

    }
}

