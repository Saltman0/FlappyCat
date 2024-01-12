using Godot;
using System;

public partial class Wall : Node2D
{
	[Signal]
	public delegate void BirdPassWallEventHandler();
	
	private int _speed = 300;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Position = new Vector2(Position.X - _speed * (float)delta, Position.Y);
		GD.Print(Position);
	}

	public void OnScoreAreaBodyExited(Player player)
	{
		GD.Print("Exited");
		EmitSignal(SignalName.BirdPassWall);
	}
}
