using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public GameObject canvas;

    private void Start()
    {
        canvas = GameObject.Find("CanvasGamePlay");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().FinishLevel();
            Time.timeScale = 0f;
            FindObjectOfType<SoundBGManager>().StopBGSound("Sunshine");
            canvas.transform.GetChild(0).gameObject.SetActive(false);
            canvas.transform.GetChild(1).gameObject.SetActive(false);
            canvas.transform.GetChild(2).gameObject.SetActive(false);
            canvas.transform.GetChild(3).gameObject.SetActive(true);
            canvas.transform.GetChild(4).gameObject.SetActive(false);

            GameWin();

            Debug.Log("You win");
        }
    }

    private void GameWin()
    {
        TextMeshProUGUI score = GameObject.Find("CanvasGamePlay/PanelFinish/Score").GetComponent<TextMeshProUGUI>();
        int scoreNum = FindObjectOfType<UIManager>().nowScore;
        score.text = "Score: " + scoreNum;

        TextMeshProUGUI highScore = GameObject.Find("CanvasGamePlay/PanelFinish/HighScore").GetComponent<TextMeshProUGUI>();

        List<LevelScore> scoreList = GameObject.Find("GameManager/GamePlay").GetComponent<GameManager>().levelInfo;


        foreach(LevelScore lvl in scoreList)
        {
            Debug.Log("sc: " + SceneManager.GetActiveScene().buildIndex + ", lvl: " + lvl.level + ", highest: " + lvl.scoreLevel);
            if (SceneManager.GetActiveScene().buildIndex ==  lvl.level && scoreNum < lvl.scoreLevel)
            {
                highScore.text = "HighScore: " + lvl.scoreLevel;
            }
            else
            {
                highScore.text = "HighScore: " + scoreNum; 
            }

        }
    }

    public void GameLose()
    {
        FindObjectOfType<GameManager>().FinishLevel();
        Time.timeScale = 0f;
        FindObjectOfType<SoundBGManager>().StopBGSound("Sunshine");
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        canvas.transform.GetChild(3).gameObject.SetActive(false);
        canvas.transform.GetChild(4).gameObject.SetActive(true);

        TextMeshProUGUI score = GameObject.Find("CanvasGamePlay/PanelLose/Score").GetComponent<TextMeshProUGUI>();
        int scoreNum = FindObjectOfType<UIManager>().nowScore;
        score.text = "Score: " + scoreNum;
    }


}
