using System;

namespace SnakeLadderGame
{
    class Ladder:Cell
    {
        public int Origin { get; set; }
        public int End { get; set; }

        public Ladder CreateLadder(int UpperLimit, int LowerLimit, int boardSize)
        {
            Random rnd = new Random();
            Ladder ladder = new Ladder();
            ladder.Origin = rnd.Next(2, (boardSize - UpperLimit));
            int sum = rnd.Next(LowerLimit, UpperLimit);
            ladder.End = ladder.Origin + sum;
            return ladder;
        }
    }
}
