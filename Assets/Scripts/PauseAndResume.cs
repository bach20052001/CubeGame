using UnityEngine;

public class PauseAndResume : MonoBehaviour
{
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
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
}
