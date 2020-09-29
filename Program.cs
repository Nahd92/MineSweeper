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
            MineSweeper game = new MineSweeper(args);

            game.Run();


        }
    }
}
