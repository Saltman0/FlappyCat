using Godot;

namespace ScrollNeon.Scripts.Factories;

public static class WallFactory
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="positionX"></param>
    /// <param name="positionY"></param>
    /// <returns></returns>
    public static Wall CreateWall(float positionX, float positionY)
    {
        Wall wall = (Wall)GD.Load<PackedScene>("res://Scenes/Wall.tscn").Instantiate();
        wall.Position = new Vector2(positionX, positionY);
        return wall;
    }
}