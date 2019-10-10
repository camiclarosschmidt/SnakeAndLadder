using System;

namespace SnakeLadderGame
{
    class Snake: Cell
    {
        public int Head { get; set; }
        public int Tail { get; set; }
        

        public Snake CreateSnake(int UpperLimit, int LowerLimit, int boardSize)
        {
            Random rnd = new Random();
            Snake snake = new Snake();
            snake.Head = rnd.Next(2, (boardSize - UpperLimit));
            int rest = rnd.Next(LowerLimit, UpperLimit);
            snake.Tail = snake.Head - rest;
            return snake;
        }
    }
}
