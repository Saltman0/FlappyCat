using Godot;

public partial class Block : Area2D
{
	/// <summary>
	/// Crash the player when it entered in the block
	/// </summary>
	/// <param name="player"></param>
	public void OnBodyEntered(Player player)
	{
		player.Crash();
	}
}
