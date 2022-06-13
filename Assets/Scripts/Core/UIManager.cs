using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI thisText;

    public int nowScore;

    private void Start()
    {
        nowScore = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            thisText.text = "Score: ";
        }
    }

    public void AddScore(int scoreNumber)
    {
        nowScore += scoreNumber;
        thisText.text = "Score: " + nowScore;
    }

}
