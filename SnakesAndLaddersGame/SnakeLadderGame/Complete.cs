using System;
using System.Collections.Generic;

namespace SnakeLadderGame
{
    public class Complete
    {
        Player currentPlayer;
        Cell[] board;
        Player[] playerRoute;
        
        public Complete(int BoardSize)
        {
            
            board = CreateBoard(BoardSize);
            playerRoute = AssignPlayers();
        }
        private Cell[] CreateBoard(int boardSize)
        {
            Cell[] board = new Cell[boardSize];
            for (int i = 0; i < boardSize; i++)
            {
                Cell c = new Cell();
                c.CellNumber = i + 1;
                board[i] = c;
            }
            int NumSnake = 4;
            int NumLadder = 4;
            int UpperLimit = 7;
            int LowerLimit = 3;
            Random rnd = new Random();
            
            for (int i = 0; i < NumLadder; i++)
            {
                Ladder ladder = new Ladder();
                ladder = ladder.CreateLadder(UpperLimit, LowerLimit, boardSize);
                board[ladder.Origin - 1] = ladder;
            }
            
            for (int i = 0; i < NumSnake; i++)
            {
                Snake snake = new Snake();
                snake = snake.CreateSnake(UpperLimit, LowerLimit, boardSize);
                board[snake.Head - 1] = snake;
                
            }
            return board;
        }
        private Player[] AssignPlayers()
        {
            Player[] players = new Player[2];
            for (int i = 0; i < 2; i++)
            {
                players[i] = new Player();
                players[i].CurrentCellPosition = 0;
                players[i].PlayerNumber = i + 1;
                
            }
            return players;
        }
        private int RollDice()
        {
                Random rnd = new Random();
                return rnd.Next(1, 7);
        }
        private void NextChance()
        {
            if (currentPlayer.PlayerNumber< 2)
            {
                
                currentPlayer = playerRoute[(currentPlayer.PlayerNumber - 1) + 1];
            }
            else
            {
                currentPlayer = playerRoute[0];
            }
        }
        private void CalculatePlayerPosition(int diceNumber)
        {
            Console.WriteLine("Player " + currentPlayer.PlayerNumber + ", your dice shows " + diceNumber);
            currentPlayer.CurrentCellPosition = PlayerPosition.MoveLocation(currentPlayer, diceNumber, board);
            currentPlayer.CurrentCellPosition = PlayerPosition.MoveSnakeTail(currentPlayer, board);
            currentPlayer.CurrentCellPosition = PlayerPosition.MoveLadderEnd(currentPlayer, board);
        }
        public void Play()
        {
            currentPlayer = playerRoute[0];
            bool isFirstMove = true;
            while (currentPlayer.CurrentCellPosition != board.Length)
            {                
                if (!isFirstMove)
                {
                    NextChance();
                }
                isFirstMove = false;
                CalculatePlayerPosition(RollDice());
            }
            Console.WriteLine("Player " + currentPlayer.PlayerNumber + " wins");
            foreach (Player p in playerRoute)
            {
                Console.WriteLine("Player " + p.PlayerNumber + " is at "+ p.CurrentCellPosition);
            }
            Console.WriteLine("Game Over!!!");
        }
    }
}
