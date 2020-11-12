using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{

    public void Play() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
