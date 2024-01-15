using Godot;
using System;

public partial class GameUI : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
	}

	public void OnPauseButtonPressed()
	{
		PauseGame();
	}

	public void OnResumeButtonPressed()
	{
		GD.Print("REsume");
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
		GetNode<Button>("ResumeAndPauseButtonsContainer/PauseButton").Visible = false;
		GetNode<Button>("ResumeAndPauseButtonsContainer/ResumeButton").Visible = true;
		GetNode<VBoxContainer>("GameOverAndButtonsContainer").Visible = true;
		GetNode<Label>("GameOverAndButtonsContainer/GameLabel").Text = "Pause";
		GetTree().Paused = true;
	}
	
	public void ResumeGame()
	{
		GetNode<Button>("ResumeAndPauseButtonsContainer/PauseButton").Visible = true;
		GetNode<Button>("ResumeAndPauseButtonsContainer/ResumeButton").Visible = false;
		GetNode<VBoxContainer>("GameOverAndButtonsContainer").Visible = true;
		GetNode<Label>("GameOverAndButtonsContainer/GameLabel").Text = "Pause";
		GetTree().Paused = false;
	}

	public void GameOver()
	{
		GetNode<VBoxContainer>("ResumeAndPauseButtonsContainer/PauseButton").Visible = false;
		GetNode<VBoxContainer>("ResumeAndPauseButtonsContainer/ResumeButton").Visible = false;
		GetNode<VBoxContainer>("GameOverAndButtonsContainer").Visible = true;
		GetNode<Label>("GameOverAndButtonsContainer/GameLabel").Text = "Game over";
	}
}
