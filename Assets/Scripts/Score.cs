using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private GameObject Player;
    private int score;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    public int GetScore()
    {
        return score + 231;
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)Player.transform.position.x;
        transform.GetComponent<Text>().text = (score + 231).ToString() + "";
    }
}
