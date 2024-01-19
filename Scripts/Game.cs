using Godot;
using System;

public partial class Game : Node
{
	[Export]
	private AudioStreamPlayer2D _gameOverAudio;
	
	[Export]
	private Timer _gameStartTimer;
	
	[Export]
	private GameUI _gameUi;
	
	private bool _isGameOver;
	
	private int _score;

	private Node2D _walls;

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
			GetNode<GameUI>("GameUI").UpdateScore(_score);
		}
	}

	public override void _Ready()
	{
		_walls = GetNode<Node2D>("Walls");
	}

	public void OnWallSpawnerSpawn(float positionX, float positionY)
	{
		Wall wall = (Wall)GD.Load<PackedScene>("res://Scenes/Wall.tscn").Instantiate();
		wall.Position = new Vector2(positionX, positionY);
		_walls.AddChild(wall);
	}

	public void OnGameStartTimerTimeout()
	{
		GetNode<WallSpawner>("WallSpawner").ProcessMode = ProcessModeEnum.Inherit;
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
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Game.tscn"));
	}

	public void OnGameUIReturnToMainMenuButtonPressed()
	{
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Menu.tscn"));
	}
}
