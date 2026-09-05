namespace TurnBase.KaNoBu
{
    public sealed class ShipPaperKaNoBuFigure : KaNoBuFigure
    {
        public ShipPaperKaNoBuFigure(int playerId, bool visibleForAllPlayers, int winNumber)
            : base(playerId, visibleForAllPlayers, winNumber)
        {
        }

        public override FigureTypes FigureType => FigureTypes.ShipPaper;

        public override bool IsMoveable => true;

        public override bool IsMoveValid(KaNoBuMoveResponseModel.MoveStep moveStep)
        {
            return moveStep.From.IsAdjacentTo(moveStep.To);
        }

        public override KaNoBuFigure ResolveBattle(KaNoBuFigure defender)
        {
            switch (defender.FigureType)
            {
                case FigureTypes.Unknown:
                    throw new System.Exception("Can not resolve battle with unknown ship");
                case FigureTypes.ShipPaper:
                    return null;
                case FigureTypes.ShipFlag:
                case FigureTypes.ShipStone:
                    return this;
                case FigureTypes.ShipScissors:
                case FigureTypes.ShipMine:
                    return defender;
                case FigureTypes.ShipUniversal:
                    return defender.WithFigureType(FigureTypes.ShipScissors);
                default:
                    throw new System.Exception($"Unsupported figure type {defender.FigureType}");
            }
        }
    }
}
