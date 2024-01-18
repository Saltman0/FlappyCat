using Godot;
using System;

public partial class GameUI : CanvasLayer
{
	[Signal]
	public delegate void GamePausedEventHandler();
	
	[Export]
	private Button _pauseButton;
	
	[Export]
	private Button _resumeButton;
	
	[Export]
	private Button _replayButton;
	
	[Export]
	private Button _returnToMainMenuButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
	}

	public override void _Input(InputEvent @inputEvent)
	{
		if (@inputEvent.IsActionPressed("pause"))
		{
			if (GetTree().Paused)
			{
				_resumeButton.EmitSignal("pressed");
			}
			else
			{
				_pauseButton.EmitSignal("pressed");
			}
		}
	}

	public void OnPauseButtonPressed()
	{
		PauseGame();
	}

	public void OnResumeButtonPressed()
	{
		ResumeGame();
	}

	public void OnReplayButtonPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Game.tscn"));
	}

	public void OnReturnToMainMenuButtonPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Main.tscn"));
	}

	public void UpdateScore(int score)
	{
		GetNode<Label>("ScoreLabel").Text = score.ToString();
	}

	public void PauseGame()
	{
		_pauseButton.Visible = false;
		_resumeButton.Visible = true;
		GetNode<VBoxContainer>("GameOverAndButtonsContainer").Visible = true;
		GetNode<Label>("GameOverAndButtonsContainer/GameLabel").Text = "Pause";
		GetNode<Label>("GameStartLabel").Visible = false;
		GetTree().Paused = true;
	}
	
	public void ResumeGame()
	{
		GetTree().Paused = false;
		_pauseButton.Visible = true;
		_resumeButton.Visible = false;
		GetNode<VBoxContainer>("GameOverAndButtonsContainer").Visible = false;
		GetNode<Label>("GameOverAndButtonsContainer/GameLabel").Text = "Pause";
		GetNode<Label>("GameStartLabel").Visible = false;
	}

	public void GameOver()
	{
		_pauseButton.Visible = false;
		_resumeButton.Visible = false;
		GetNode<VBoxContainer>("GameOverAndButtonsContainer").Visible = true;
		GetNode<Label>("GameOverAndButtonsContainer/GameLabel").Text = "Game over";
		GetNode<Label>("GameStartLabel").Visible = false;
	}

	public void HideGameStartLabel()
	{
		GetNode<Label>("GameStartLabel").Visible = false;
	}
}
