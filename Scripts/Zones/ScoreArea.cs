using Godot;
using System;

public partial class ScoreArea : Area2D
{
	/// <summary>
	/// Pass the player when it exit the body of the score area
	/// </summary>
	/// <param name="player"></param>
	public void OnBodyExited(Player player)
	{
		player.Pass();
	}
}
