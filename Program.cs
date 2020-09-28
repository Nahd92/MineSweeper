using System;

namespace MineSweeper
{
    /// <summary>
    /// Inlämningsarbetet 'MineSweeper' är skapat av Dhan och Felix Kristoffersson.
    /// </summary>

    class Program
    {

        static void Main(string[] args)
        {
            var gameEngine = new GameEngine(args);
            //  Helper.Initialize();
            //  Helper.BoobyTrapped();


            // Denna funktion startar spelet.
            gameEngine.Run();






        }
    }
}
