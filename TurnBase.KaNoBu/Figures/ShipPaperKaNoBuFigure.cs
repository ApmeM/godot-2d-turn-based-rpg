namespace TurnBase.KaNoBu
{
    public sealed class ShipPaperKaNoBuFigure : KaNoBuFigure
    {
        public ShipPaperKaNoBuFigure(int playerId, bool visibleForAllPlayers, int winNumber)
            : base(playerId, FigureTypes.ShipPaper, visibleForAllPlayers, winNumber)
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
                defender.FigureType = FigureTypes.ShipScissors;
                return defender;
            }

            if (defender.FigureType == FigureTypes.ShipScissors)
            {
                return defender;
            }

            if (defender.FigureType == FigureTypes.ShipStone)
            {
                return this;
            }

            return null;
        }
    }
}
