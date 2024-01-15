using Godot;
using System;

public partial class SceneTransition : Node
{
    private PackedScene _newScene;
    public void ChangeScene(PackedScene newScene = null)
    {
        _newScene = newScene;
        GetNode<AnimationPlayer>("AnimationPlayer").Play("Fade");
    }
    
    public void OnAnimationPlayerAnimationFinished(string animationName)
    {
        if (animationName == "Fade")
        {
            if (_newScene != null)
            {
                GetTree().ChangeSceneToPacked(_newScene);
            }
            GetNode<AnimationPlayer>("AnimationPlayer").PlayBackwards("Fade");
        }
    }
}