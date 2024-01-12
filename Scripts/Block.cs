using Godot;
using System;

public partial class Block : Area2D
{
	[Signal]
	public delegate void BirdCrashedEventHandler();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
	}

	public void OnBodyEntered(Player player)
	{
		EmitSignal(SignalName.BirdCrashed);
	}
}
