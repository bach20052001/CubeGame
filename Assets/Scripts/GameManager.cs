using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isOver = false;
    public GameObject RestartPanel;
    public GameObject ROP;
    public Score score;
    private int CurrentScore;
    private string str;

    private void Start()
    {     
        RestartPanel.SetActive(false);
    }
    private void ExportScore()
    {
        StreamWriter writer = new StreamWriter("/RGame/Assets/Resources/Text/Score.txt", true);
        CurrentScore = score.GetComponent<Score>().GetScore();
        str = CurrentScore.ToString() + "\n";
        writer.Write(str);
        writer.Close();
    }
    public void GameOver()
    {
        if (!isOver)
        {
            isOver = true;
            RestartPanel.SetActive(true);
            score.GetComponent<Score>().enabled = false;
            GetComponent<AutoGenarateObstacles>().CancelInvoke();
            GetComponent<AutoGenerateBridge>().CancelInvoke();
            ExportScore();
            ROP.SetActive(false);
        }
    }    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
