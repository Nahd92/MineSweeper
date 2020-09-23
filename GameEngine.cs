using System;

namespace MineSweeper
{
    public class GameEngine
    {
        bool IsWinning = false;
        bool IsLosing = false;
        bool[,] usersInput;



        //Tar fram boarden.  
        public void GenerateBoard()
        {
            Board board = new Board();
            board.DisplayBoard();
        }



        //Agera hjärta och inneha all logik till spelet. 
        public void StartGame()
        {
            do
            {
                GenerateBoard();

            } while (IsWinning);



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
