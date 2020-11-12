using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject Player;
    private int score;

    public int GetScore()
    {
        return score;
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)Player.transform.position.x;
        transform.GetComponent<Text>().text = score.ToString() + "";
    }
}
