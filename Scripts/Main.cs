using Godot;
using System;

public partial class Main : Node
{
    public void OnMenuInterfacePlayGame()
    {
        /*GetNode<SceneTransition>("/root/SceneTransition").ChangeScene(ResourceLoader.Load<PackedScene>("res://Scenes/Game.tscn"));*/
        GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Game.tscn"));
    }
    
    public void OnMenuInterfaceExitGame()
    {
        GetTree().Quit();
    }
}
