using NUnit.Framework;
using TurnBase.KaNoBu;

[TestFixture]
public class KaNoBuBattleTests
{
    [TestCase(KaNoBuFigure.FigureTypes.ShipStone, KaNoBuFigure.FigureTypes.ShipStone, null)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipStone, KaNoBuFigure.FigureTypes.ShipPaper, KaNoBuFigure.FigureTypes.ShipPaper)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipStone, KaNoBuFigure.FigureTypes.ShipScissors, KaNoBuFigure.FigureTypes.ShipStone)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipStone, KaNoBuFigure.FigureTypes.ShipFlag, KaNoBuFigure.FigureTypes.ShipStone)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipStone, KaNoBuFigure.FigureTypes.ShipMine, KaNoBuFigure.FigureTypes.ShipMine)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipStone, KaNoBuFigure.FigureTypes.ShipUniversal, KaNoBuFigure.FigureTypes.ShipPaper)]

    [TestCase(KaNoBuFigure.FigureTypes.ShipPaper, KaNoBuFigure.FigureTypes.ShipStone, KaNoBuFigure.FigureTypes.ShipPaper)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipPaper, KaNoBuFigure.FigureTypes.ShipPaper, null)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipPaper, KaNoBuFigure.FigureTypes.ShipScissors, KaNoBuFigure.FigureTypes.ShipScissors)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipPaper, KaNoBuFigure.FigureTypes.ShipFlag, KaNoBuFigure.FigureTypes.ShipPaper)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipPaper, KaNoBuFigure.FigureTypes.ShipMine, KaNoBuFigure.FigureTypes.ShipMine)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipPaper, KaNoBuFigure.FigureTypes.ShipUniversal, KaNoBuFigure.FigureTypes.ShipScissors)]

    [TestCase(KaNoBuFigure.FigureTypes.ShipScissors, KaNoBuFigure.FigureTypes.ShipStone, KaNoBuFigure.FigureTypes.ShipStone)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipScissors, KaNoBuFigure.FigureTypes.ShipPaper, KaNoBuFigure.FigureTypes.ShipScissors)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipScissors, KaNoBuFigure.FigureTypes.ShipScissors, null)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipScissors, KaNoBuFigure.FigureTypes.ShipFlag, KaNoBuFigure.FigureTypes.ShipScissors)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipScissors, KaNoBuFigure.FigureTypes.ShipMine, KaNoBuFigure.FigureTypes.ShipMine)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipScissors, KaNoBuFigure.FigureTypes.ShipUniversal, KaNoBuFigure.FigureTypes.ShipStone)]

    [TestCase(KaNoBuFigure.FigureTypes.ShipFlag, KaNoBuFigure.FigureTypes.ShipStone, KaNoBuFigure.FigureTypes.ShipStone)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipFlag, KaNoBuFigure.FigureTypes.ShipPaper, KaNoBuFigure.FigureTypes.ShipPaper)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipFlag, KaNoBuFigure.FigureTypes.ShipScissors, KaNoBuFigure.FigureTypes.ShipScissors)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipFlag, KaNoBuFigure.FigureTypes.ShipFlag, null)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipFlag, KaNoBuFigure.FigureTypes.ShipMine, KaNoBuFigure.FigureTypes.ShipMine)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipFlag, KaNoBuFigure.FigureTypes.ShipUniversal, KaNoBuFigure.FigureTypes.ShipUniversal)]

    [TestCase(KaNoBuFigure.FigureTypes.ShipMine, KaNoBuFigure.FigureTypes.ShipStone, KaNoBuFigure.FigureTypes.ShipMine)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipMine, KaNoBuFigure.FigureTypes.ShipPaper, KaNoBuFigure.FigureTypes.ShipMine)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipMine, KaNoBuFigure.FigureTypes.ShipScissors, KaNoBuFigure.FigureTypes.ShipMine)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipMine, KaNoBuFigure.FigureTypes.ShipFlag, KaNoBuFigure.FigureTypes.ShipMine)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipMine, KaNoBuFigure.FigureTypes.ShipMine, null)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipMine, KaNoBuFigure.FigureTypes.ShipUniversal, KaNoBuFigure.FigureTypes.ShipMine)]

    [TestCase(KaNoBuFigure.FigureTypes.ShipUniversal, KaNoBuFigure.FigureTypes.ShipStone, KaNoBuFigure.FigureTypes.ShipPaper)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipUniversal, KaNoBuFigure.FigureTypes.ShipPaper, KaNoBuFigure.FigureTypes.ShipScissors)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipUniversal, KaNoBuFigure.FigureTypes.ShipScissors, KaNoBuFigure.FigureTypes.ShipStone)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipUniversal, KaNoBuFigure.FigureTypes.ShipFlag, KaNoBuFigure.FigureTypes.ShipUniversal)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipUniversal, KaNoBuFigure.FigureTypes.ShipMine, KaNoBuFigure.FigureTypes.ShipMine)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipUniversal, KaNoBuFigure.FigureTypes.ShipUniversal, null)]
    public void BattlesAsExpected(KaNoBuFigure.FigureTypes attackerType, KaNoBuFigure.FigureTypes defenderType, KaNoBuFigure.FigureTypes? expectedWinnerType)
    {
        var attacker = KaNoBuFigure.Create(1, attackerType, true, 0);
        var defender = KaNoBuFigure.Create(2, defenderType, true, 0);

        var winner = attacker.ResolveBattle(defender);

        if (expectedWinnerType == null)
        {
            Assert.That(winner, Is.Null);
            return;
        }

        Assert.That(winner, Is.Not.Null);
        Assert.That(winner.FigureType, Is.EqualTo(expectedWinnerType.Value));

        if (winner == attacker)
        {
            Assert.That(attacker.FigureType, Is.EqualTo(expectedWinnerType.Value));
        }
        else
        {
            Assert.That(defender.FigureType, Is.EqualTo(expectedWinnerType.Value));
        }
    }
}
