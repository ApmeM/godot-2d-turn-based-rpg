using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TurnBase;
using TurnBase.KaNoBu;

[TestFixture]
public class KaNoBuPlayerMediumTests
{
    [Test]
    public async Task MediumBotSkipsWallDestinations()
    {
        var player = new KaNoBuPlayerMedium();
        var field = Field2D.Create(2, 2);
        field[0, 0] = KaNoBuFigure.Create(0, KaNoBuFigure.FigureTypes.ShipStone, true, 0);
        field.walls[0, 1] = true;
        field.walls[1, 0] = true;

        var result = await player.MakeTurn(new MakeTurnModel<KaNoBuMoveModel>
        {
            Request = new KaNoBuMoveModel(field)
        });

        Assert.That(result.Response.Status, Is.EqualTo(KaNoBuMoveResponseModel.MoveStatus.SKIP_TURN));
    }
}
