using Godot;

public partial class Block : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
	}

	public void OnBodyEntered(Player player)
	{
		player.Crash();
	}
}
