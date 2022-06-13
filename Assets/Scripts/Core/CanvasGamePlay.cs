using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CanvasGamePlay : MonoBehaviour
{
    public AudioMixer audi;

    public float sliderValue;

    public GameObject sliderVolumn;
    public TextMeshProUGUI volumnText;

    public void SetVolumn()
    {
        sliderValue = sliderVolumn.GetComponent<Slider>().value;
        int cloneText = (int)(sliderValue * 100);        
        volumnText.text = cloneText.ToString() + " %";
        audi.SetFloat("MusicVolumn", Mathf.Log10(sliderValue) * 20);
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
    }

    public void ResumeLevel()
    {
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //PoolManager.Instance.Clear();

        Time.timeScale = 1f;
    }

    public void BackToMenus()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<SoundBGManager>().PlayBGSound("Sunshine");
        Time.timeScale = 1f;
    }

    public void ClickSound()
    {

        FindObjectOfType<SoundManager>().PlaySound("Click");

        //int randomClick = Random.Range(1, 3);

        //switch (randomClick)
        //{
        //    case 1:
        //        FindObjectOfType<SoundManager>().PlaySound("Click");
        //        break;
        //    case 2:
        //        FindObjectOfType<SoundManager>().PlaySound("Click2");
        //        break;
        //    case 3:
        //        FindObjectOfType<SoundManager>().PlaySound("Click3");
        //        break;
        //    default:
        //        break;
        //}
    }

    public void NextLvl()
    {
        if ((SceneManager.GetActiveScene().buildIndex + 1) > SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            BackToMenus();
        }
    }

}
