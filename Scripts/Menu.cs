using Godot;
using System;

public partial class Menu : Node2D
{
    [Export]
    private MenuInterface _menuInterface;

    private PackedScene _gameScene = ResourceLoader.Load<PackedScene>("res://Scenes/Game.tscn");
    
    public void OnMenuInterfacePlayButtonPressed()
    {
        GetTree().ChangeSceneToPacked(_gameScene);
    }
    
    public void OnMenuInterfaceExitButtonPressed()
    {
        GetTree().Quit();
    }
}
