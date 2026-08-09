using Godot;

[SceneReference("LevelMap.tscn")]
public partial class LevelMap
{
    [Signal]
    public delegate void LevelSelected(LevelMapUnit mapUnit);

    public override void _Ready()
    {
        this.FillMembers();

        this.level1.Connect(nameof(Unit.UnitClicked), this, nameof(OnLevelPressed), new Godot.Collections.Array { this.level1 });
        this.level2.Connect(nameof(Unit.UnitClicked), this, nameof(OnLevelPressed), new Godot.Collections.Array { this.level2 });
    }

    public async void OnLevelPressed(LevelMapUnit mapUnit)
    {
        await this.player.RotateUnitToAction(mapUnit.Position);
        await this.player.MoveUnitToAction(mapUnit.Position - (mapUnit.Position - this.player.Position).Normalized() * 64);
        await mapUnit.RotateUnitToAction(this.player.Position);
        this.EmitSignal(nameof(LevelSelected), mapUnit);
    }

    public async void LevelFinished(LevelMapUnit mapUnit, bool result)
    {
        if (result)
        {
            await this.player.AttackAction();
            mapUnit.IsClickable = false;
            await mapUnit.UnitHitAction();
        }
        else
        {
            var scene = new PackedScene();

            var packResult = scene.Pack(this.player);
            if (packResult != Error.Ok)
            {
                GD.PrintErr($"Не удалось запаковать Node: {packResult}");
                return;
            }

            var newPlayer = scene.Instance<Unit>();;
            this.field.AddChild(newPlayer);
            this.player.Visible = false;
            await newPlayer.UnitHitAction();
            
            this.player.Position = new Vector2(85, 710);
            await this.player.RotateUnitToAction(new Vector2(85, 670));
            this.player.Visible = true;
            await this.player.MoveUnitToAction(new Vector2(85, 670));
        }
    }
}
