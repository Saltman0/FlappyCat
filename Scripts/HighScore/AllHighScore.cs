using Godot;
using System;

public partial class AllHighScore : Resource
{
    [Export]
    private int[] _highScores = new int[10];
}
