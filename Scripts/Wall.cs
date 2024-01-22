using Godot;

public partial class Wall : Node2D
{
	[Export]
	private int _speed = 300;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Position = new Vector2(Position.X - _speed * (float)delta, Position.Y);
	}

	/// <summary>
	/// Event when the player exit the score area
	/// </summary>
	/// <param name="player"></param>
	public void OnScoreAreaBodyExited(Player player)
	{
		player.Pass();
	}

	/// <summary>
	/// Destroy the wall when the timer is timeout
	/// </summary>
	public void OnWallTimerTimeout()
	{
		QueueFree();
	}
}
