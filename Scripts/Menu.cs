using Godot;
using System;

public partial class Menu : Node2D
{
    [Export]
    private MenuInterface _menuInterface;

    private PackedScene _gameScene = ResourceLoader.Load<PackedScene>("res://Scenes/Game.tscn");
    
    /// <summary>
    /// Change the scene tree to the game scene when the "Play" button is pressed
    /// </summary>
    public void OnMenuInterfacePlayButtonPressed()
    {
        GetTree().ChangeSceneToPacked(_gameScene);
    }
    
    /// <summary>
    /// Quit the game when the "Exit" button is pressed
    /// </summary>
    public void OnMenuInterfaceExitButtonPressed()
    {
        GetTree().Quit();
    }
}
