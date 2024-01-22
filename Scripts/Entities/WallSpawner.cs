using Godot;
using System;
using ScrollNeon.Scripts.Factories;

public partial class WallSpawner : Node2D
{
	[Signal]
	public delegate void WallSpawnedEventHandler(float positionX, float positionY);

	/// <summary>
	/// Create a wall and emit a "WallSpawned" signal when the timer is timeout
	/// </summary>
	public void OnWallSpawnerTimerTimeout()
	{
		EmitSignal(
			SignalName.WallSpawned, 
			WallFactory.CreateWall(
				GlobalPosition.X, 
				(float)GD.RandRange(
					GetNode<Marker2D>("WallSpawnMarkerTop").GlobalPosition.Y, 
					GetNode<Marker2D>("WallSpawnMarkerDown").GlobalPosition.Y
				)
			)
		);
	}
}
