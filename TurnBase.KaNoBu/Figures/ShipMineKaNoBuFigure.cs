namespace TurnBase.KaNoBu
{
    public sealed class ShipMineKaNoBuFigure : KaNoBuFigure
    {
        public ShipMineKaNoBuFigure(int playerId, bool visibleForAllPlayers, int winNumber)
            : base(playerId, FigureTypes.ShipMine, visibleForAllPlayers, winNumber)
        {
        }

        public override bool IsMoveValid(KaNoBuMoveResponseModel playerMove)
        {
            return false;
        }

        public override KaNoBuFigure ResolveBattle(KaNoBuFigure defender)
        {
            if (defender.FigureType == FigureTypes.ShipMine)
            {
                return null;
            }

            return this;
        }
    }
}
