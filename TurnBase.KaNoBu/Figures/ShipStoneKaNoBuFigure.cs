namespace TurnBase.KaNoBu
{
    public sealed class ShipStoneKaNoBuFigure : KaNoBuFigure
    {
        public ShipStoneKaNoBuFigure(int playerId, bool visibleForAllPlayers, int winNumber)
            : base(playerId, FigureTypes.ShipStone, visibleForAllPlayers, winNumber)
        {
        }

        public override bool IsMoveValid(KaNoBuMoveResponseModel playerMove)
        {
            return playerMove.From.IsAdjacentTo(playerMove.To);
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
                defender.FigureType = FigureTypes.ShipPaper;
                return defender;
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
