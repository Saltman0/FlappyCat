using Godot;
using System;
using System.Collections.Generic;

public partial class AllHighScore : Resource
{
    private List<int> _highScores = new List<int>();

    /// <summary>
    /// Add a new highscore
    /// </summary>
    /// <param name="highscore"></param>
    public void AddHighScore(int highscore)
    {
        _highScores.Add(highscore);
        _highScores.Sort();
        _highScores.Reverse();
    }
}
