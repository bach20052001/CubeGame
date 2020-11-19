using System.IO;
using System.Text;
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
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        StreamWriter writer = new StreamWriter("/RGame/Assets/Resources/Text/Score.txt", true);
        CurrentScore = score.GetComponent<Score>().GetScore();
        str = CurrentScore.ToString() + "\n";
        writer.Write(str);
        writer.Close();
#endif
#if UNITY_ANDROID && !UNITY_EDITOR
        StreamWriter theWriter = new StreamWriter(Application.persistentDataPath + "/Text" + "/Score.txt");

        CurrentScore = score.GetComponent<Score>().GetScore();
        
        str = CurrentScore.ToString() + "\n";

        theWriter.Write(str);

        theWriter.Close();
#endif
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
            GetComponent<HorizonMove>().enabled = false;
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
