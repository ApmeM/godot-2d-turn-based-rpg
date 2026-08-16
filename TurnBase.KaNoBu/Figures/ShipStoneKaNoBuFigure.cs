namespace TurnBase.KaNoBu
{
    public sealed class ShipStoneKaNoBuFigure : KaNoBuFigure
    {
        public ShipStoneKaNoBuFigure(int playerId, bool visibleForAllPlayers, int winNumber)
            : base(playerId, visibleForAllPlayers, winNumber)
        {
        }

        public override FigureTypes FigureType => FigureTypes.ShipStone;

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
                return defender.WithFigureType(FigureTypes.ShipPaper);
            }

            if (defender.FigureType == FigureTypes.ShipPaper)
            {
                return defender;
            }

            if (defender.FigureType == FigureTypes.ShipScissors)
            {
                return this;
            }

            return null;
        }
    }
}
