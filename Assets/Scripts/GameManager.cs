using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private bool isOver = false;
    
    public bool IsOver
    {
        get
        {
            return isOver;
        }
    }

    [SerializeField] private GameObject RestartPanel;
    [SerializeField] private GameObject pauseOrResume;
    [SerializeField] private Score score;
    private int CurrentScore;
    private string str;
    [SerializeField] private Text ButtonText;
    private bool isPause = false;
    [SerializeField] private PoolingManager poolingManager;
    private void Start()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<GameManager>();
        }
        if (instance != this)
        {
            Destroy(gameObject);
        }
        
        RestartPanel.SetActive(false);
    }
    private void ExportScore()
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        StreamWriter writer = new StreamWriter("Assets/Resources/Text/Score.txt", true);
        CurrentScore = score.GetScore();
        str = CurrentScore.ToString() + "\n";
        writer.Write(str);
        writer.Close();
#endif
#if UNITY_ANDROID && !UNITY_EDITOR
        StreamWriter theWriter = new StreamWriter(Application.persistentDataPath + "/Score.txt");

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
            ExportScore();
            score.enabled = false;
            pauseOrResume.SetActive(false);
            poolingManager.StopAllCoroutines();
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
