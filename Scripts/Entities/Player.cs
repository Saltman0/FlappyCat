using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float JumpVelocity = -600.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		velocity.Y += ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle() * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump"))
			velocity.Y = JumpVelocity;

		Velocity = velocity;
		
		MoveAndSlide();
	}
}
