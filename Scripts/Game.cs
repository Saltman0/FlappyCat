using Godot;
using System;

public partial class Game : Node
{
    PackedScene _wallScene = GD.Load<PackedScene>("res://Scenes/Wall.tscn");
    
    public override void _Ready()
    {
    }
    public void OnWallSpawnTimerTimeout()
    {
        Wall wall = (Wall)_wallScene.Instantiate();
        AddChild(wall);

        Rect2 viewportRect = GetViewport().GetVisibleRect();

        wall.Position = new Vector2(
            viewportRect.End.X + 50, 
            (float)GD.RandRange(
                viewportRect.Size.Y * 0.15,
                viewportRect.Size.Y * 0.65
            )
        );
    }
}
