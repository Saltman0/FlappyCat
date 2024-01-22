using Godot;

public partial class Player : CharacterBody2D
{
	private int _speed = 300;

	private bool _crashed;
	
	[Export]
	private AudioStreamPlayer2D _playerJumpAudio;
	
	[Signal]
	public delegate void PassedEventHandler();
	
	[Signal]
	public delegate void CrashedEventHandler();
	
	public const int JumpVelocity = -600;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity.Y += ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
		Velocity = velocity;
		MoveAndSlide();
	}
	
	public override void _Input(InputEvent @inputEvent)
	{
		if (@inputEvent.IsActionPressed("jump"))
		{
			Jump();
		}
	}

	/// <summary>
	/// Perform a jump
	/// </summary>
	public void Jump()
	{
		if (_crashed == false) 
		{
			Velocity = new Vector2(0, JumpVelocity);
			_playerJumpAudio.Play();
		}
	}
	
	/// <summary>
	/// Emit a signal when the player passed something
	/// </summary>
	public void Pass()
	{
		EmitSignal(SignalName.Passed);
	}

	/// <summary>
	/// Crash the player, perform a jump and emit a "Crashed" signal
	/// </summary>
	public void Crash()
	{
		if (_crashed == false)
		{
			_crashed = true;
			Velocity = new Vector2(0, Velocity.Y + JumpVelocity);
			EmitSignal(SignalName.Crashed);
		}
	}
}
