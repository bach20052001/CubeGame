using UnityEngine;

public class SelectLevel : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject SelectGUI;
    public GameObject GamePlay;
    public GameObject ROP;


    private void InitialGame()
    {
        GamePlay.SetActive(true);
        SelectGUI.SetActive(false);
        transform.gameObject.SetActive(true);
        ROP.SetActive(true);

#if UNITY_ANDROID
        transform.gameObject.GetComponent<HorizonMove>().enabled = true;
#endif

    }

    public void SetHard()
    {
        InitialGame();
        rb.GetComponent<Rigidbody>().drag = 0.75f;
        transform.gameObject.GetComponent<AutoGenarateObstacles>().SetTime(0.65f);
        transform.gameObject.GetComponent<AutoGenerateBridge>().SetTime(12f);
#if UNITY_ANDROID
        transform.gameObject.GetComponent<HorizonMove>().SetSpeedTouch(75f);
#endif
    }
    public void SetNormal()
    {
        InitialGame();
        rb.GetComponent<Rigidbody>().drag = 1f;
        transform.gameObject.GetComponent<AutoGenarateObstacles>().SetTime(0.75f);
        transform.gameObject.GetComponent<AutoGenerateBridge>().SetTime(10f);
#if UNITY_ANDROID
        transform.gameObject.GetComponent<HorizonMove>().SetSpeedTouch(60f);
#endif
    }

    public void SetEasy()
    {
        InitialGame();
        rb.GetComponent<Rigidbody>().drag = 1.25f;
        transform.gameObject.GetComponent<AutoGenarateObstacles>().SetTime(0.85f);
        transform.gameObject.GetComponent<AutoGenerateBridge>().SetTime(10f);
#if UNITY_ANDROID
        transform.gameObject.GetComponent<HorizonMove>().SetSpeedTouch(60f);
#endif
    }
}
