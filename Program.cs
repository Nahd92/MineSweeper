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
            var Engine = new GameEngine();
            // Helper.Initialize(string[] args);
            // var boobyRowAndCol = Helper.BoobyTrapped(10, 10);
            //Tar fram boarden.  
            Engine.GenerateBoard();



        }
    }
}
