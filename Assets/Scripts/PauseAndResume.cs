using UnityEngine;
using UnityEngine.UI;

public class PauseAndResume : MonoBehaviour
{
    public Text ButtonText;
    private bool isPause = false;
    private void PauseGame()
    {
        isPause = true;
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        isPause = false;
        Time.timeScale = 1;
    }

    public void Active()
    {
        if (isPause)
        {
            ButtonText.GetComponent<Text>().text = "Pause";
            ResumeGame();
        }
        else
        {
            ButtonText.GetComponent<Text>().text = "Resume";
            PauseGame();
        }
    }
}
