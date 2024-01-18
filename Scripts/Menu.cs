using Godot;
using System;

public partial class Menu : Node2D
{
    [Export]
    private MenuInterface _menuInterface;
    
    [Signal]
    public delegate void GamePlayedEventHandler();
    
    [Signal]
    public delegate void GameExitedEventHandler();
    
    public void OnMenuInterfacePlayGame()
    {
        EmitSignal(SignalName.GamePlayed);
    }
    
    public void OnMenuInterfaceExitGame()
    {
        EmitSignal(SignalName.GameExited);
    }
    
    public void Disable()
    {
        _menuInterface.Visible = false;
        ProcessMode = ProcessModeEnum.Disabled;
    }
}
