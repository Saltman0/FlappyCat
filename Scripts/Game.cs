using Godot;
using System;

public partial class Game : Node
{
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

	public override void _PhysicsProcess(double delta)
	{
		GetNode<Label>("GameStartLabel").Text = Convert.ToInt16(GetNode<Timer>("GameStartTimer").TimeLeft).ToString();
		if (Convert.ToInt16(GetNode<Timer>("GameStartTimer").TimeLeft) == 0)
		{
			GetNode<Label>("GameStartLabel").Visible = false;
		}
		if (Input.IsActionJustPressed("pause"))
		{
			
		}
	}

	public void OnWallSpawnerSpawn(float positionX, float positionY)
	{
		// TODO FAire appaaite un mur
		Wall wall = (Wall)GD.Load<PackedScene>("res://Scenes/Wall.tscn").Instantiate();
		wall.Position = new Vector2(positionX, positionY);
		_walls.AddChild(wall);
	}

	public void OnGameStartTimerTimeout()
	{
		GetNode<WallSpawner>("WallSpawner").ProcessMode = ProcessModeEnum.Always;
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
		GetNode<GameUI>("GameUI").GameOver();
	}
}
