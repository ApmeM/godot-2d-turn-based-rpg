using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Godot;
using TurnBase;
using TurnBase.KaNoBu;

[SceneReference("Main.tscn")]
public partial class Main
{
    [Export]
    public PackedScene Replay;

    private List<ICommunicationModel> lastReplay;

    public override void _Ready()
    {
        this.FillMembers();

        this.uI.Connect(nameof(UI.StartGameEventhandler), this, nameof(OnStartGame));
        this.levelMap.Connect(nameof(LevelMap.LevelSelected), this, nameof(OnLevelPressed));
        this.exitGameButton.Connect(CommonSignals.Pressed, this, nameof(EndCurrentGame));
        this.mainMenuButton.Connect(CommonSignals.Pressed, this, nameof(ShowMainMenuPopup));
        this.customButton.Connect(CommonSignals.Pressed, this, nameof(ShowCustomUI));
        this.replayButton.Connect(CommonSignals.Pressed, this, nameof(OnReplayPressed));

        PlayerFailProtection<KaNoBuInitModel, KaNoBuInitResponseModel, KaNoBuMoveModel, KaNoBuMoveResponseModel, KaNoBuMoveNotificationModel>.logger = new GDLogger();
    }

    private async void OnLevelPressed(LevelMapUnit mapUnit)
    {
        var field = mapUnit.GameToLaunch.Instance<LevelBase>();
        field.Initialize();
        field.Game.AddGameLogListener(new ReadableLogger<KaNoBuMoveNotificationModel>(new GDLogger()));
        this.AttachReplayStorageListener(field);
        var result = await this.StartGame(field);
        levelMap.LevelFinished(mapUnit, result);
    }

    private void ShowMainMenuPopup()
    {
        this.mainMenuPopup.Show();
    }

    private void ShowCustomUI()
    {
        this.uI.Show();
    }

    private void AttachReplayStorageListener(GameField field)
    {
        var replayMemoryStorageListener = new MemoryStorageEventListener<KaNoBuMoveNotificationModel>();
        this.lastReplay = replayMemoryStorageListener.Events;
        field.Game.AddGameLogListener(replayMemoryStorageListener);
    }

    // private async void StartInfinityGame()
    // {
    //     while (true)
    //     {
    //         var rules = new KaNoBuRules(8);
    //         rules.AllFiguresVisible = true;
    //         var kanobu = new Game<KaNoBuInitModel, KaNoBuInitResponseModel, KaNoBuMoveModel, KaNoBuMoveResponseModel, KaNoBuMoveNotificationModel>(rules, "test");
    //         for (var i = 0; i < 4; i++)
    //         {
    //             var playerEasy = new KaNoBuPlayerEasy();
    //             var delayedPlayer = new DelayedPlayer<KaNoBuInitModel, KaNoBuInitResponseModel, KaNoBuMoveModel, KaNoBuMoveResponseModel, KaNoBuMoveNotificationModel>(
    //                 playerEasy,
    //                 async (delay) => await this.ToSignal(this.GetTree().CreateTimer(delay / 1000f), "timeout"),
    //                 1,
    //                 300);
    //             kanobu.AddPlayer(delayedPlayer);
    //         }
    //         kanobu.AddGameLogListener(this.infinityGameField);
    //         await kanobu.Play();
    //     }
    // }


    private async void OnStartGame()
    {
        await this.OnStartGameAsync();
    }

    private async Task OnStartGameAsync()
    {
        var game = this.uI.BuildGame();
        this.AttachReplayStorageListener(game);
        await this.StartGame(game);
    }

    private async void OnReplayPressed()
    {
        if (this.lastReplay == null || this.lastReplay.Count == 0)
        {
            GD.PrintErr("No replay available to start.");
            return;
        }

        var field = this.Replay.Instance<GameField>();
        field.Game = new ReplayGame<KaNoBuInitModel, KaNoBuInitResponseModel, KaNoBuMoveModel, KaNoBuMoveResponseModel, KaNoBuMoveNotificationModel>(new List<ICommunicationModel>(this.lastReplay));
        field.Game.AddGameLogListener(field);
        field.Game.AddGameLogListener(new ReadableLogger<KaNoBuMoveNotificationModel>(new GDLogger()));

        await this.StartGame(field);
    }

    private CancellationTokenSource currentGameCancellationTokenSource;

    private async Task<bool> StartGame(GameField game)
    {
        if (game == null)
        {
            return false;
        }

        this.replayButton.Visible = false;
        this.uI.Visible = false;

        this.AddChild(game);
        this.SetCameraLimits(game.Water);

        this.draggableCamera.Current = true;
        this.draggableCamera.Position = this.staticCamera.Position;
        this.draggableCamera.Scale = this.staticCamera.Scale;
        this.draggableCamera.Zoom = this.staticCamera.Zoom;

        if (this.currentGameCancellationTokenSource != null)
        {
            this.currentGameCancellationTokenSource.Cancel();
            this.currentGameCancellationTokenSource = null;
        }

        this.currentGameCancellationTokenSource = new CancellationTokenSource();

        try
        {
            await game.Play(this.currentGameCancellationTokenSource.Token);
        }
        catch (OperationCanceledException)
        {
        }

        return await this.EndGame(game);
    }

    private async void EndCurrentGame()
    {
        this.mainMenuPopup.Hide();
        this.currentGameCancellationTokenSource?.Cancel();
    }

    private async Task<bool> EndGame(GameField gameField)
    {
        var result = false;

        var fieldPlayerId = gameField.playerId;
        var winners = gameField.Winners?.ToHashSet();
        if (fieldPlayerId == -1)
        {
            this.winnerLabel.Text = $"The game is over.";
        }
        if (winners?.Contains(fieldPlayerId) ?? false)
        {
            this.winnerLabel.Text = "You win.";
            result = true;
        }
        else
        {
            this.winnerLabel.Text = "You loose.";
        }

        this.replayButton.Visible = true;
        this.gameOverPopup.Show();
        await this.ToSignal(this.gameOverPopup, nameof(CustomPopup.PopupClosed));

        gameField.Game.Disconnect(gameField);
        gameField.QueueFree();

        // this.uI.Visible = true;
        this.staticCamera.Current = true;
        return result;
    }

    public void SetCameraLimits(TileMap field)
    {
        this.draggableCamera.SetCameraLimits(field, Vector2.Zero);
    }
}
