using Godot;
using System;
using System.Threading.Tasks;

[SceneReference("Dialog.tscn")]
public partial class Dialog
{

    private TaskCompletionSource<bool> showCompletion;

    [Export]
    public int Speed;
    public override void _Ready()
    {
        base._Ready();
        this.FillMembers();

        this.timer.Connect(CommonSignals.Timeout, this, nameof(Timer_Timeout));
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && ((ButtonList)mouseEvent.ButtonMask).HasFlag(ButtonList.Left))
        {
            ForceFinish();
        }

        if (@event is InputEventKey keyEvent && keyEvent.Pressed && (((KeyList)keyEvent.Scancode).HasFlag(KeyList.Space) || ((KeyList)keyEvent.Scancode).HasFlag(KeyList.Escape)))
        {
            ForceFinish();
        }
    }

    protected void Timer_Timeout()
    {
        this.dialogTestLabel.VisibleCharacters++;
        if (this.dialogTestLabel.VisibleCharacters > this.dialogTestLabel.Text.Length)
        {
            this.timer.Stop();
        }
    }

    public Task Show(string text, bool left, Texture image)
    {
        if (this.showCompletion != null && !this.showCompletion.Task.IsCompleted)
        {
            this.showCompletion.TrySetCanceled();
        }

        this.showCompletion = new TaskCompletionSource<bool>();

        this.Show();
        this.dialogTestLabel.Text = text;
        this.dialogTestLabel.VisibleCharacters = 0;

        this.leftFace.Texture = image ?? this.leftFace.Texture;
        this.rightFace.Texture = image ?? this.rightFace.Texture;
        this.leftFace.Visible = left;
        this.rightFace.Visible = !left;

        this.timer.Start();

        return this.showCompletion.Task;
    }

    public void ForceFinish()
    {
        if (this.dialogTestLabel.VisibleCharacters < this.dialogTestLabel.Text.Length)
        {
            this.dialogTestLabel.VisibleCharacters = this.dialogTestLabel.Text.Length;
            this.timer.Stop();
        }
        else
        {
            this.Hide();
            this.showCompletion?.TrySetResult(true);
        }
    }

    public override void _ExitTree()
    {
        if (this.showCompletion != null && !this.showCompletion.Task.IsCompleted)
        {
            this.showCompletion.TrySetCanceled();
        }

        base._ExitTree();
    }

}
