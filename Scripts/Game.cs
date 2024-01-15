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
		if (Input.IsActionJustPressed("pause"))
		{
			
		}
	}
	
	public void OnWallSpawnTimerTimeout()
	{
		Wall wall = (Wall)GD.Load<PackedScene>("res://Scenes/Wall.tscn").Instantiate();
		_walls.AddChild(wall);

		Rect2 viewportRect = GetViewport().GetVisibleRect();

		wall.Position = new Vector2(
			viewportRect.End.X, 
			(float)GD.RandRange(
				viewportRect.Size.Y * 0.15,
				viewportRect.Size.Y * 0.65
			)
		);
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
