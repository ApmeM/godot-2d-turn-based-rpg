namespace TurnBase.KaNoBu
{
    public sealed class UnknownKaNoBuFigure : KaNoBuFigure
    {
        public UnknownKaNoBuFigure(int playerId, bool visibleForAllPlayers, int winNumber)
            : base(playerId, visibleForAllPlayers, winNumber)
        {
        }

        public override FigureTypes FigureType => FigureTypes.Unknown;

        public override bool IsMoveValid(KaNoBuMoveResponseModel playerMove)
        {
            return false;
        }

        public override KaNoBuFigure ResolveBattle(KaNoBuFigure defender)
        {
            return null;
        }
    }
}
