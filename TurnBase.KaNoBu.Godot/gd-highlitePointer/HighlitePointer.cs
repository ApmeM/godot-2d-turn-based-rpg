using System;
using System.Threading.Tasks;
using Godot;

/// <summary>
/// Full-screen tutorial overlay. Add the HighlitePointer scene to the UI and await Show.
/// The position is in viewport (screen) coordinates.
/// </summary>
[SceneReference("HighlitePointer.tscn")]
public partial class HighlitePointer
{
    private TaskCompletionSource<bool> clickCompletion;

    /// <summary>
    /// Shows a dimmed screen with a circular transparent area and waits for a tap in it.
    /// Calling Show again cancels the previous pending task.
    /// </summary>
    public Task Show(Vector2 position, float radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be greater than zero.");
        }

        if (this.clickCompletion != null && !this.clickCompletion.Task.IsCompleted)
        {
            this.clickCompletion.TrySetCanceled();
        }

        var shadeMaterial = (ShaderMaterial)this.shade.Material;
        shadeMaterial.SetShaderParam("hole_center", position);
        shadeMaterial.SetShaderParam("hole_radius", radius);
        shadeMaterial.SetShaderParam("viewport_size", this.GetViewport().Size);

        this.fingerAnimation.RectPosition = position - this.finger.RectSize - Vector2.One.Normalized() * radius / 2;

        this.clickCompletion = new TaskCompletionSource<bool>();
        this.overlay.Show();
        return clickCompletion.Task;
    }

    public override void _Ready()
    {
        base._Ready();
        this.FillMembers();
        this.Visible = true;
        this.overlay.Connect("gui_input", this, nameof(OnOverlayGuiInput));
        this.overlay.Hide();
    }

    public override void _ExitTree()
    {
        if (this.clickCompletion != null && !this.clickCompletion.Task.IsCompleted)
        {
            this.clickCompletion.TrySetCanceled();
        }

        base._ExitTree();
    }

    private void OnOverlayGuiInput(InputEvent @event)
    {
        Vector2 clickPosition;
        if (@event is InputEventMouseButton mouse)
        {
            if (!mouse.Pressed || mouse.ButtonIndex != (int)ButtonList.Left)
            {
                return;
            }

            clickPosition = mouse.Position;
        }
        else if (@event is InputEventScreenTouch touch)
        {
            if (!touch.Pressed)
            {
                return;
            }

            clickPosition = touch.Position;
        }
        else
        {
            return;
        }

        var material = (ShaderMaterial)this.shade.Material;
        var center = (Vector2)material.GetShaderParam("hole_center");
        var radius = (float)material.GetShaderParam("hole_radius");
        if (clickPosition.DistanceTo(center) > radius)
        {
            return;
        }

        this.overlay.Hide();
        this.clickCompletion?.TrySetResult(true);
    }
}
