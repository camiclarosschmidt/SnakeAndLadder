using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeLadderGame
{
    static class PlayerPosition
    {
        public static int MoveLocation(Player player, int diceNumber, Cell[] boardSize)
        {
            if ((player.CurrentCellPosition + diceNumber) <= boardSize.Length)
            {
                player.CurrentCellPosition = player.CurrentCellPosition + diceNumber;
                Console.WriteLine("Player " + player.PlayerNumber + ", moved to " + player.CurrentCellPosition);
            }
            else
            {
                Console.WriteLine("Player " + player.PlayerNumber + ", returns to " + (boardSize.Length - (player.CurrentCellPosition - boardSize.Length)));
            }
            return player.CurrentCellPosition;
            
        }
        public static int MoveSnakeTail(Player player, Cell[] board)
        {
            if (board[player.CurrentCellPosition - 1].GetType() == typeof(Snake))
            {
                player.CurrentCellPosition = (board[player.CurrentCellPosition - 1] as Snake).Tail;
                Console.WriteLine("Player " + player.PlayerNumber + "Snake, moving " + player.CurrentCellPosition);
            }
            return player.CurrentCellPosition;
        }
        public static int MoveLadderEnd(Player player, Cell[] board)
        {
            if (board[player.CurrentCellPosition - 1].GetType() == typeof(Ladder))
            {
                player.CurrentCellPosition = (board[player.CurrentCellPosition - 1] as Ladder).End;
                Console.WriteLine("Player " + player.PlayerNumber + " Ladder, moving " + player.CurrentCellPosition);
            }
            return player.CurrentCellPosition;
        }
    }
}
