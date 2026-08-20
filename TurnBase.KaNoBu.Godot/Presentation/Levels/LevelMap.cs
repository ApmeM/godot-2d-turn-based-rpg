using Godot;

[SceneReference("LevelMap.tscn")]
public partial class LevelMap
{
    [Signal]
    public delegate void LevelSelected(LevelMapUnit mapUnit);

    public override void _Ready()
    {
        this.FillMembers();

        foreach (var mapUnit in this.GetTree().GetNodesInGroup(Groups.LevelButton))
        {
            if (mapUnit is LevelMapUnit levelMapUnit)
            {
                levelMapUnit.Connect(nameof(Unit.UnitClicked), this, nameof(OnLevelPressed), new Godot.Collections.Array { levelMapUnit });
            }
        }
    }

    public override async void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("left_click") && @event is InputEventMouseButton mouseEvent)
        {
            this.GetTree().SetInputAsHandled();
            this.player.CancelActions();
            this.player.RotateUnitTo(mouseEvent.Position);
            this.player.MoveUnitTo(mouseEvent.Position);
        }
    }

    public async void OnLevelPressed(LevelMapUnit mapUnit)
    {
        this.player.CancelActions();
        this.player.RotateUnitTo(mapUnit.Position);
        this.player.MoveUnitTo(mapUnit.Position - (mapUnit.Position - this.player.Position).Normalized() * 64);
        this.player.CallbackForUnit((unit) => mapUnit.RotateUnitToAction(this.player.Position));
        this.player.CallbackForUnit(async (unit) => this.EmitSignal(nameof(LevelSelected), mapUnit));
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
