namespace TurnBase.KaNoBu
{
    public sealed class UnknownKaNoBuFigure : KaNoBuFigure
    {
        public UnknownKaNoBuFigure(int playerId, bool visibleForAllPlayers, int winNumber)
            : base(playerId, visibleForAllPlayers, winNumber)
        {
        }

        public override FigureTypes FigureType => FigureTypes.Unknown;

        public override bool IsMoveable => false;

        public override bool IsMoveValid(KaNoBuMoveResponseModel.MoveStep moveStep)
        {
            return false;
        }

        public override KaNoBuFigure ResolveBattle(KaNoBuFigure defender)
        {
            return null;
        }
    }
}
