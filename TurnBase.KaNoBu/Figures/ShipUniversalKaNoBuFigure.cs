namespace TurnBase.KaNoBu
{
    public sealed class ShipUniversalKaNoBuFigure : KaNoBuFigure
    {
        public ShipUniversalKaNoBuFigure(int playerId, bool visibleForAllPlayers, int winNumber)
            : base(playerId, FigureTypes.ShipUniversal, visibleForAllPlayers, winNumber)
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
                return null;
            }

            this.FigureType = GetTypeThatDefeats(defender.FigureType);
            return this;
        }
    }
}
