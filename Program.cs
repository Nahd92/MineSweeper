

namespace MineSweeper
{
    /// <summary>
    /// Inlämningsarbetet 'MineSweeper' är skapat av Dhan och Felix Kristoffersson.
    /// </summary>

    class Program
    {

        static int Main(string[] args)
        {
            MineSweeper game = new MineSweeper(args);
            return game.Run();


        }
    }
}
