using NUnit.Framework;
using TurnBase;
using TurnBase.KaNoBu;

[TestFixture]
public class KaNoBuRulesTests
{
    [Test]
    public void PromotionKeepsCorrectBattleResult()
    {
        var field = Field2D.Create(2, 2);
        var attacker = KaNoBuFigure.Create(1, KaNoBuFigure.FigureTypes.ShipStone, true, 2);
        var defender = KaNoBuFigure.Create(2, KaNoBuFigure.FigureTypes.ShipScissors, true, 0);
        field[0, 0] = attacker;
        field[1, 0] = defender;

        var rules = new KaNoBuRules(6);
        var move = new KaNoBuMoveResponseModel(
            KaNoBuMoveResponseModel.MoveStatus.MAKE_TURN,
            new Point { X = 0, Y = 0 },
            new Point { X = 1, Y = 0 });

        var notification = rules.MakeMove(field, 1, move);

        Assert.That(notification.battle, Is.Not.Null);
        Assert.That(notification.battle.Value.battleResult, Is.EqualTo(KaNoBuMoveNotificationModel.BattleResult.AttackerWon));

        var placed = (KaNoBuFigure)field[1, 0];
        Assert.That(placed, Is.Not.Null);
        Assert.That(placed.FigureType, Is.EqualTo(KaNoBuFigure.FigureTypes.ShipUniversal));
        Assert.That(placed.PlayerId, Is.EqualTo(1));
    }

    [Test]
    public void BattleResultUsesPlayerIdentityWhenWinnerInstanceChanges()
    {
        var field = Field2D.Create(2, 2);
        var attacker = new FakeWinningFigure(1, KaNoBuFigure.FigureTypes.ShipUniversal, true, 0);
        var defender = KaNoBuFigure.Create(2, KaNoBuFigure.FigureTypes.ShipStone, true, 0);
        field[0, 0] = attacker;
        field[1, 0] = defender;

        var rules = new KaNoBuRules(6);
        var move = new KaNoBuMoveResponseModel(
            KaNoBuMoveResponseModel.MoveStatus.MAKE_TURN,
            new Point { X = 0, Y = 0 },
            new Point { X = 1, Y = 0 });

        var notification = rules.MakeMove(field, 1, move);

        Assert.That(notification.battle, Is.Not.Null);
        Assert.That(notification.battle.Value.battleResult, Is.EqualTo(KaNoBuMoveNotificationModel.BattleResult.AttackerWon));
    }

    private sealed class FakeWinningFigure : KaNoBuFigure
    {
        private readonly KaNoBuFigure.FigureTypes _type;
        public FakeWinningFigure(int playerId, KaNoBuFigure.FigureTypes figureType, bool visibleForAllPlayers, int winNumber)
            : base(playerId, visibleForAllPlayers, winNumber)
        {
            _type = figureType;
        }

        public override KaNoBuFigure.FigureTypes FigureType => _type;

        public override bool IsMoveValid(KaNoBuMoveResponseModel playerMove) => true;

        public override KaNoBuFigure ResolveBattle(KaNoBuFigure defender)
        {
            return KaNoBuFigure.Create(this.PlayerId, KaNoBuFigure.FigureTypes.ShipStone, true, 0);
        }
    }
}
