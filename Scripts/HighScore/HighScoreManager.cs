using Godot;
using System;

public partial class HighScoreManager : Node
{
    private string _allHighscorePath = "user://AllHighcore.tres";
    
    /// <summary>
    /// Save a new highscore
    /// </summary>
    /// <param name="highscore"></param>
    public void SaveHighscore(int highscore)
    {
        AllHighScore allHighScore;
        // TODO Check and create a new AllHighScore if it doesn't exit
        if (ResourceLoader.Exists(_allHighscorePath))
        {
            allHighScore = ResourceLoader.Load<AllHighScore>(_allHighscorePath);
        }
        else
        {
            allHighScore = new AllHighScore();
        }

        // TODO Add the new highscore and sort the AllHighScore by the highest score
        allHighScore.AddHighScore(highscore);

        // TODO Confirm and save the AllHighScore
        ResourceSaver.Save(allHighScore, _allHighscorePath);
    }

    /// <summary>
    /// Load the AllHighScore file
    /// </summary>
    /// <returns></returns>
    public AllHighScore LoadAllHighScore()
    {
        return ResourceLoader.Exists(_allHighscorePath) 
            ? ResourceLoader.Load<AllHighScore>(_allHighscorePath) 
            : new AllHighScore();
    }
}
