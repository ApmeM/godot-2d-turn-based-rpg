namespace TurnBase.KaNoBu
{
    public sealed class ShipStoneKaNoBuFigure : KaNoBuFigure
    {
        public ShipStoneKaNoBuFigure(int playerId, bool visibleForAllPlayers, int winNumber)
            : base(playerId, visibleForAllPlayers, winNumber)
        {
        }

        public override FigureTypes FigureType => FigureTypes.ShipStone;

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
                case FigureTypes.ShipStone:
                    return null;
                case FigureTypes.ShipFlag:
                case FigureTypes.ShipScissors:
                    return this;
                case FigureTypes.ShipMine:
                case FigureTypes.ShipPaper:
                    return defender;
                case FigureTypes.ShipUniversal:
                    return defender.WithFigureType(FigureTypes.ShipPaper);
                default:
                    throw new System.Exception($"Unsupported figure type {defender.FigureType}");
            }
        }
    }
}
