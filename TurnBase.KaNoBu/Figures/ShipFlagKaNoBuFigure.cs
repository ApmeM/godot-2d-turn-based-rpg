namespace TurnBase.KaNoBu
{
    public sealed class ShipFlagKaNoBuFigure : KaNoBuFigure
    {
        public ShipFlagKaNoBuFigure(int playerId, bool visibleForAllPlayers, int winNumber)
            : base(playerId, visibleForAllPlayers, winNumber)
        {
        }

        public override FigureTypes FigureType => FigureTypes.ShipFlag;

        public override bool IsMoveValid(KaNoBuMoveResponseModel.MoveStep moveStep)
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
