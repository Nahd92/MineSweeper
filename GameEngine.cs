using System;

namespace MineSweeper
{
    public class GameEngine
    {
        bool IsWinning = false;
        bool IsLosing = false;

        //Tar fram boarden.  
        public void GenerateBoard()
        {
            Board board = new Board();
            board.DrawBoard();
        }

        public void StartGame()  //Agera hjärta och inneha all logik till spelet. 
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
