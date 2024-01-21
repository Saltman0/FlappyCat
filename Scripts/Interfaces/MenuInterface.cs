using Godot;
using System;

public partial class MenuInterface : CanvasLayer
{
	[Export] 
	private Button _playButton;

	[Export] 
	private Button _exitButton;
	
	[Signal]
	public delegate void PlayButtonPressedEventHandler();
	
	[Signal]
	public delegate void ExitButtonPressedEventHandler();

	public void OnPlayButtonPressed()
	{
		EmitSignal(SignalName.PlayButtonPressed);
	}
	
	public void OnExitButtonPressed()
	{
		EmitSignal(SignalName.ExitButtonPressed);
	}
}
