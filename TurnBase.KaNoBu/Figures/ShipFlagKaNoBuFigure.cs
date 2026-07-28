namespace TurnBase.KaNoBu
{
    public sealed class ShipFlagKaNoBuFigure : KaNoBuFigure
    {
        public ShipFlagKaNoBuFigure(int playerId, bool visibleForAllPlayers, int winNumber)
            : base(playerId, FigureTypes.ShipFlag, visibleForAllPlayers, winNumber)
        {
        }

        public override bool IsMoveValid(KaNoBuMoveResponseModel playerMove)
        {
            return false;
        }

        public override KaNoBuFigure ResolveBattle(KaNoBuFigure defender)
        {
            if (defender.FigureType == FigureTypes.ShipFlag)
            {
                return null;
            }

            return defender;
        }
    }
}
