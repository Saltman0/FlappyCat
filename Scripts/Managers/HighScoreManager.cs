using Godot;
using System;

public partial class HighScoreManager : Resource
{
    private string _savePath = "user://HighScore.save";
    
    public void SaveHighScore(int highscore)
    {
        FileAccess _saveGame = FileAccess.Open(_savePath, FileAccess.ModeFlags.Write);
        
        _saveGame.StoreVar(465);
    }
    
    public void LoadHighScore()
    {
        FileAccess _saveGame = FileAccess.Open(_savePath, FileAccess.ModeFlags.Read);
        
        /*_saveGame.GetVar()*/
    }
}
