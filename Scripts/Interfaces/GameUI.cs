using Godot;
using System;

public partial class GameUI : Control
{
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
		if (Input.IsActionJustPressed("pause"))
		{
			_pauseButton.EmitSignal("pressed");
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
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Game.tscn"));
	}

	public void OnReturnToMainMenuButtonPressed()
	{
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
		GetTree().Paused = true;
	}
	
	public void ResumeGame()
	{
		_pauseButton.Visible = true;
		_resumeButton.Visible = false;
		GetNode<VBoxContainer>("GameOverAndButtonsContainer").Visible = false;
		GetNode<Label>("GameOverAndButtonsContainer/GameLabel").Text = "Pause";
		GetTree().Paused = false;
	}

	public void GameOver()
	{
		_pauseButton.Visible = false;
		_resumeButton.Visible = false;
		GetNode<VBoxContainer>("GameOverAndButtonsContainer").Visible = true;
		GetNode<Label>("GameOverAndButtonsContainer/GameLabel").Text = "Game over";
	}
}
