using Godot;
using System;

public partial class Game : Node2D
{
	private PackedScene _menuScene = ResourceLoader.Load<PackedScene>("res://Scenes/Menu.tscn");
	
	private PackedScene _gameScene = ResourceLoader.Load<PackedScene>("res://Scenes/Game.tscn");
	
	[Export]
	private Node2D _walls;
	
	[Export]
	private WallSpawner _wallSpawner;
	
	[Export]
	private AudioStreamPlayer2D _gameOverAudio;
	
	[Export]
	private Timer _gameStartTimer;
	
	[Export]
	private GameUI _gameUi;
	
	private bool _isGameOver;
	
	private int _score;

	public bool IsGameOver
	{
		get => _isGameOver;
		set => _isGameOver = value;
	}

	public int Score
	{
		get => _score;
		set
		{
			_score = value;
			_gameUi.UpdateScore(_score);
		}
	}

	public void OnWallSpawnerWallSpawned(Wall wall)
	{
		_walls.AddChild(wall);
	}

	public void OnGameStartTimerTimeout()
	{
		_wallSpawner.ProcessMode = ProcessModeEnum.Inherit;
		_gameUi.HideGameStartLabel();
	}

	public void OnPlayerPassed()
	{
		if (!IsGameOver)
		{
			Score++;
		}
	}
	
	public void OnPlayerCrashed()
	{
		IsGameOver = true;
		_gameStartTimer.Stop();
		_gameOverAudio.Play();
		_gameUi.GameOver();
	}

	public void Enable()
	{
		_gameUi.Visible = true;
		ProcessMode = ProcessModeEnum.Always;
	}

	public void OnGameUIReplayButtonPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToPacked(_gameScene);
	}

	public void OnGameUIReturnToMainMenuButtonPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToPacked(_menuScene);
	}
}
