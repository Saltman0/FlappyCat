using Godot;
using System;

public partial class MenuInterface : Control
{
	[Signal]
	public delegate void PlayGameEventHandler();
	
	[Signal]
	public delegate void ExitGameEventHandler();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnPlayButtonPressed()
	{
		EmitSignal(SignalName.PlayGame);
	}
	
	public void OnExitButtonPressed()
	{
		EmitSignal(SignalName.ExitGame);
	}
}
