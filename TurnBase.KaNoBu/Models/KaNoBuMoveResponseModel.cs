using System.Collections.Generic;

namespace TurnBase.KaNoBu
{
    public class KaNoBuMoveResponseModel
    {
        public struct MoveStep
        {
            public MoveStep(Point from, Point to)
            {
                From = from;
                To = to;
            }

            public readonly Point From;
            public readonly Point To;
        }

        public KaNoBuMoveResponseModel(List<MoveStep> moves)
        {
            Moves = moves ?? new List<MoveStep>();
        }

        public readonly List<MoveStep> Moves;
    }
}