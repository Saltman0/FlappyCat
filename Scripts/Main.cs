using Godot;
using System;

public partial class Main : Node2D
{
    [Export]
    private Menu _menu;
    
    [Export]
    private Game _game;

    public void OnMenuGameExited()
    {
        GetTree().Quit();
    }
    
    public void OnMenuGamePlayed()
    {
        _menu.Disable();
        _game.Enable();
    }
}
