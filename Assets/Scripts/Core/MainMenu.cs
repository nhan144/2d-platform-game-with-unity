using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //public void ShowLevelInfo(int levelNumber)
    //{
    //    FindObjectOfType<GameManager>().getList
    //}

    public void PlaySelectLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void PlaySelectLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void playBgSound(int number)
    { 
        switch (number)
        {
            case 0:
                FindObjectOfType<SoundBGManager>().PlayBGSound("Sunshine");
                break;

            default:
                FindObjectOfType<SoundBGManager>().PlayBGSound("Sunshine");
                break;
        }
    }

}
