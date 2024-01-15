using Godot;

public partial class Player : CharacterBody2D
{
	private int _speed = 300;

	private bool _crashed;
	
	[Signal]
	public delegate void PassedEventHandler();
	
	[Signal]
	public delegate void CrashedEventHandler();
	
	public const int JumpVelocity = -600;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		velocity.Y += ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
		
		if (_crashed == false)
		{
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
		if (_crashed == false)
		{
			Velocity = new Vector2(0, Velocity.Y + JumpVelocity);
			_crashed = true;
			EmitSignal(SignalName.Crashed);
		}
	}
}
