using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ReadScore : MonoBehaviour
{
    private string str;
    private List<int> ScoreList = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        StreamReader reader = new StreamReader("/RGame/Assets/Text/Score.txt");
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            ScoreList.Add(Convert.ToInt32(line));
        }
        ScoreList.Sort();
        ScoreList.Reverse();
        for (int i = 0; i < ScoreList.Count; i++)
        {
            str += "Top " + (i+1) + " : " + ScoreList[i].ToString() + "\n";
        }
      
        reader.Close();

        GetComponent<Text>().text = str;
    }
}
