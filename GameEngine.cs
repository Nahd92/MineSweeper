using System;

namespace MineSweeper
{
    public struct GameEngine
    {
        static bool IsWinning = false;
        static bool IsLosing = false;


        //Tar fram boarden.  
        public void GenerateBoard()
        {
            Board.DisplayBoard();
            Board.FillBoard();
        }


        //Agera hjärta och inneha all logik till spelet. 
        public void StartGame()
        {
            GenerateBoard();





        }












        public static void Lost()
        {
            Console.Write("You Lost");
        }
        public static void Winning()
        {
            Console.Write("You Won!");
        }
    }
}
