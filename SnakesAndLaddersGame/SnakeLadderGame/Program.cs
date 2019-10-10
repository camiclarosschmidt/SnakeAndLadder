using System;

namespace SnakeLadderGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int boardsize = 50;
            Complete game = new Complete(boardsize);
            game.Play();

            Console.ReadKey();
        }
    }
}
