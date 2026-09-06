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

        public override BattleResolution ResolveBattle(KaNoBuFigure defender)
        {
            switch (defender.FigureType)
            {
                case FigureTypes.Unknown:
                    throw new System.Exception("Can not resolve battle with unknown ship");
                case FigureTypes.ShipFlag:
                    return BattleResolution.AttackerWon(this);
                case FigureTypes.ShipStone:
                    return BattleResolution.AttackerWon(WithFigureType(FigureTypes.ShipPaper));
                case FigureTypes.ShipPaper:
                    return BattleResolution.AttackerWon(WithFigureType(FigureTypes.ShipScissors));
                case FigureTypes.ShipScissors:
                    return BattleResolution.AttackerWon(WithFigureType(FigureTypes.ShipStone));
                case FigureTypes.ShipUniversal:
                    return BattleResolution.Draw();
                case FigureTypes.ShipMine:
                    return BattleResolution.BothAreDestroyed();
                default:
                    throw new System.Exception($"Unsupported figure type {defender.FigureType}");
            }
        }
    }
}
