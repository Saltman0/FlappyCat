using Godot;

public partial class Player : CharacterBody2D
{
	private int _speed = 300;

	private bool _crashed;
	
	[Signal]
	public delegate void PassedEventHandler();
	
	[Signal]
	public delegate void CrashedEventHandler();
	
	public const float JumpVelocity = -600.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		velocity.Y += ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
		
		if (_crashed == false)
		{
			GD.Print(_crashed);
			if (Input.IsActionJustPressed("jump"))
			{
				velocity.Y = JumpVelocity;
			}
		}

		Velocity = velocity;
		
		MoveAndSlide();
	}
	
	public void Pass()
	{
		EmitSignal(SignalName.Passed);
	}

	public void Crash()
	{
		_crashed = true;
		EmitSignal(SignalName.Crashed);
	}
}
