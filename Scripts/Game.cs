using Godot;

public partial class Game : Node
{
	private bool _isGameOver;
	
	private int _score;
	
	private PackedScene _menuScene = ResourceLoader.Load<PackedScene>("res://Scenes/Menu.tscn");
	
	private PackedScene _gameScene = ResourceLoader.Load<PackedScene>("res://Scenes/Game.tscn");
	
	[Export]
	private Node2D _walls;

	[Export]
	private Player _player;
	
	[Export]
	private WallSpawner _wallSpawner;
	
	[Export]
	private AudioStreamPlayer2D _gameOverAudio;
	
	[Export]
	private Timer _gameStartTimer;
	
	[Export]
	private GameUI _gameUi;

	[Export]
	private DayBackground _dayBackground;

	/// <summary>
	/// Get and set if the game is over
	/// </summary>
	public bool IsGameOver
	{
		get => _isGameOver;
		set => _isGameOver = value;
	}

	/// <summary>
	/// Get and set (and update) score
	/// </summary>
	public int Score
	{
		get => _score;
		set
		{
			_score = value;
			_gameUi.UpdateScore(_score);
		}
	}
	
	/// <summary>
	/// Enable the wall spawner and hide the "Ready" label when the "Game start" timer is timeout
	/// </summary>
	public void OnGameStartTimerTimeout()
	{
		_player.ProcessMode = ProcessModeEnum.Inherit;
		_wallSpawner.ProcessMode = ProcessModeEnum.Inherit;
		_dayBackground.ScrollEnabled = true;
		_gameUi.HideGameStartLabel();
	}

	/// <summary>
	/// Add a wall when the wall spawner spawn something
	/// </summary>
	/// <param name="wall"></param>
	public void OnWallSpawnerWallSpawned(Wall wall)
	{
		_walls.AddChild(wall);
	}
	
	/// <summary>
	/// Game is over, save the score and update the best score when the player crashed
	/// </summary>
	public void OnPlayerCrashed()
	{
		IsGameOver = true;
		_gameStartTimer.Stop();
		_gameOverAudio.Play();
		_gameUi.GameOver();
		GetNode<ScoreManager>("/root/ScoreManager").SaveScore(_score);
		_gameUi.UpdateBestScore();
	}

	/// <summary>
	/// Increment score when the player passed through the area between the two blocks of the wall
	/// </summary>
	public void OnPlayerPassed()
	{
		if (!IsGameOver)
		{
			Score++;
		}
	}

	/// <summary>
	/// Pause the game when the "Pause" button is pressed
	/// </summary>
	public void OnGameUIPauseButtonPressed()
	{
		_gameUi.PauseGame();
	}
	
	/// <summary>
	/// Replay the game when the "Replay" button is pressed
	/// </summary>
	public void OnGameUIReplayButtonPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToPacked(_gameScene);
	}

	/// <summary>
	/// Resume the game when the "Resume" button is pressed
	/// </summary>
	public void OnGameUIResumeButtonPressed()
	{
		_gameUi.ResumeGame();
	}

	/// <summary>
	/// Return to the main menu when the "Return to menu" is pressed
	/// </summary>
	public void OnGameUIReturnToMainMenuButtonPressed()
	{
		GetTree().Paused = false;
		GetNode<SceneTransition>("/root/SceneTransition").ChangeScene(_menuScene);
	}

	public void OnGameUIJumpButtonPressed()
	{
		_player.Jump();
	}
}
