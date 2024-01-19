using Godot;
using System;

public partial class Menu : Node
{
    [Export]
    private MenuInterface _menuInterface;
    
    public void OnMenuInterfacePlayButtonPressed()
    {
        GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Game.tscn"));
    }
    
    public void OnMenuInterfaceExitButtonPressed()
    {
        GetTree().Quit();
    }
}
