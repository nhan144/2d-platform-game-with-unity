using UnityEngine;

[System.Serializable]
public class LevelScore 
{
    public int level;

    public int scoreLevel;

    public LevelScore(int _level, int _score)
    {
        level = _level;
        scoreLevel = _score;
    }
}
