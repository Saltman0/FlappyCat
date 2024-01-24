using Godot;

public partial class SceneTransition : CanvasLayer
{
    private PackedScene _newScene;

    [Export]
    private AnimationPlayer _animationPlayer;

    public void ChangeScene(PackedScene newScene)
    {
        _newScene = newScene;
        _animationPlayer.Play("Fade");
        /*GetTree().ChangeSceneToPacked(_newScene);*/
        /*_animationPlayer.PlayBackwards("Fade");*/
    }
    
    public void OnAnimationPlayerAnimationFinished(string animationName)
    {
        GD.Print("Animation finished");
        GetTree().ChangeSceneToPacked(_newScene);
    }
}