using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }
        else
            Destroy(this.transform.parent.gameObject);

        DontDestroyOnLoad(this.transform.parent.gameObject);
    }


    [SerializeField]
    private int score;

    [SerializeField]
    private int currentLevel;

    public List<LevelScore> levelInfo;

    //private void Update()
    //{
    //    DontDestroyOnLoad(this.transform.parent.gameObject);
    //}


    public void FinishLevel()
    {
        score = FindObjectOfType<UIManager>().nowScore;

        currentLevel = SceneManager.GetActiveScene().buildIndex;


        if (levelInfo.Count() == 0)
        {
            AddScoreToList(currentLevel, score);
        }
        else
        {
            foreach (LevelScore levelPlayed in levelInfo.ToList())
            {
                if (levelPlayed.level == currentLevel)
                {
                    if (score >= levelPlayed.scoreLevel)
                        levelPlayed.scoreLevel = score;
                }
                else
                {
                    AddScoreToList(currentLevel, score);
                }
            }
        }
    }

    private void AddScoreToList(int addLevel, int addScore)
    {
        LevelScore currentScore = new LevelScore(addLevel, addScore);
        levelInfo.Add(currentScore);
    }

}
