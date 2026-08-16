namespace TurnBase.KaNoBu
{
    public sealed class ShipScissorsKaNoBuFigure : KaNoBuFigure
    {
        public ShipScissorsKaNoBuFigure(int playerId, bool visibleForAllPlayers, int winNumber)
            : base(playerId, visibleForAllPlayers, winNumber)
        {
        }

        public override FigureTypes FigureType => FigureTypes.ShipScissors;

        public override bool IsMoveValid(KaNoBuMoveResponseModel.MoveStep moveStep)
        {
            return moveStep.From.IsAdjacentTo(moveStep.To);
        }

        public override KaNoBuFigure ResolveBattle(KaNoBuFigure defender)
        {
            if (defender.FigureType == FigureTypes.ShipFlag)
            {
                return this;
            }

            if (defender.FigureType == FigureTypes.ShipMine)
            {
                return defender;
            }

            if (defender.FigureType == FigureTypes.ShipUniversal)
            {
                return defender.WithFigureType(FigureTypes.ShipStone);
            }

            if (defender.FigureType == FigureTypes.ShipStone)
            {
                return defender;
            }

            if (defender.FigureType == FigureTypes.ShipPaper)
            {
                return this;
            }

            return null;
        }
    }
}
