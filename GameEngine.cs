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
            Board board = new Board();

            board.DisplayBoard();
            board.FillBoard();
        }


        //Agera hjärta och inneha all logik till spelet. 
        public void StartGame()
        {

            GenerateBoard();





        }












        public void Lost()
        {
            Console.Write("You Lost");
        }
        public void Winning()
        {
            Console.Write("You Won!");
        }
    }
}
