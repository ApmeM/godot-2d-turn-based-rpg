using NUnit.Framework;
using TurnBase;
using TurnBase.KaNoBu;

[TestFixture]
public class KaNoBuMoveTests
{
    [TestCase(KaNoBuFigure.FigureTypes.ShipStone, true)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipPaper, true)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipScissors, true)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipUniversal, true)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipFlag, false)]
    [TestCase(KaNoBuFigure.FigureTypes.ShipMine, false)]
    [TestCase(KaNoBuFigure.FigureTypes.Unknown, false)]
    public void FigureMovementDependsOnType(KaNoBuFigure.FigureTypes figureType, bool expectedCanMove)
    {
        var figure = KaNoBuFigure.Create(1, figureType, true, 0);

        var adjacentMove = new KaNoBuMoveResponseModel.MoveStep(
            new Point { X = 1, Y = 1 },
            new Point { X = 1, Y = 2 });

        var nonAdjacentMove = new KaNoBuMoveResponseModel.MoveStep(
            new Point { X = 1, Y = 1 },
            new Point { X = 3, Y = 3 });

        Assert.That(figure.IsMoveValid(adjacentMove), Is.EqualTo(expectedCanMove));
        Assert.That(figure.IsMoveValid(nonAdjacentMove), Is.False);
    }
}
