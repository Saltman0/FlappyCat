using Godot;
using System;

public partial class WallSpawner : Node2D
{
	[Signal]
	public delegate void WallSpawnedEventHandler(float positionX, float positionY);
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnWallSpawnerTimerTimeout()
	{
		Wall wall = (Wall)GD.Load<PackedScene>("res://Scenes/Wall.tscn").Instantiate();
		wall.Position = new Vector2(
			GlobalPosition.X, 
			(float)GD.RandRange(
				GetNode<Marker2D>("WallSpawnMarkerTop").GlobalPosition.Y, 
				GetNode<Marker2D>("WallSpawnMarkerDown").GlobalPosition.Y
			)
		);
		EmitSignal(SignalName.WallSpawned, wall);
	}
}
