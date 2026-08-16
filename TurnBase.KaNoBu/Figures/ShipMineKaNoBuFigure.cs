namespace TurnBase.KaNoBu
{
    public sealed class ShipMineKaNoBuFigure : KaNoBuFigure
    {
        public ShipMineKaNoBuFigure(int playerId, bool visibleForAllPlayers, int winNumber)
            : base(playerId, visibleForAllPlayers, winNumber)
        {
        }

        public override FigureTypes FigureType => FigureTypes.ShipMine;

        public override bool IsMoveable => false;

        public override bool IsMoveValid(KaNoBuMoveResponseModel.MoveStep moveStep)
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
