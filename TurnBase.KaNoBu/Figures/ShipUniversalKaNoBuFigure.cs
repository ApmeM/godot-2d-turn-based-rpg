namespace TurnBase.KaNoBu
{
    public sealed class ShipUniversalKaNoBuFigure : KaNoBuFigure
    {
        public ShipUniversalKaNoBuFigure(int playerId, bool visibleForAllPlayers, int winNumber)
            : base(playerId, visibleForAllPlayers, winNumber)
        {
        }

        public override FigureTypes FigureType => FigureTypes.ShipUniversal;

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
                case FigureTypes.ShipFlag:
                    return this;
                case FigureTypes.ShipStone:
                    return defender.WithFigureType(FigureTypes.ShipPaper);
                case FigureTypes.ShipPaper:
                    return defender.WithFigureType(FigureTypes.ShipScissors);
                case FigureTypes.ShipScissors:
                    return defender.WithFigureType(FigureTypes.ShipStone);
                case FigureTypes.ShipUniversal:
                    return null;
                case FigureTypes.ShipMine:
                    return defender;
                default:
                    throw new System.Exception($"Unsupported figure type {defender.FigureType}");
            }
        }
    }
}
