using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ReadScore : MonoBehaviour
{
    private string str;
    private List<int> ScoreList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        StreamReader reader = new StreamReader("/RGame/Assets/Resources/Text/Score.txt");
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            ScoreList.Add(Convert.ToInt32(line));
        }
        ScoreList.Sort();
        ScoreList.Reverse();
        for (int i = 0; i < ScoreList.Count; i++)
        {
            str += "Top " + (i + 1) + " : " + ScoreList[i].ToString() + "\n";
        }

        reader.Close();

        GetComponent<Text>().text = str;
#endif

#if UNITY_ANDROID
        try
        {
            TextAsset txtAsset = (TextAsset)Resources.Load("Score.text", typeof(TextAsset));
            
            string txtContent = txtAsset.text;
            
            File.WriteAllText(Application.persistentDataPath + "/" + "Score.text", txtContent, Encoding.UTF8);
            
            StreamReader theReader = new StreamReader(Application.persistentDataPath + "/" + "Score.text", Encoding.UTF8);
            
            string lineM;
            
            while ((lineM = theReader.ReadLine()) != null)
            {
                ScoreList.Add(Convert.ToInt32(line));
            }

            ScoreList.Sort();
            ScoreList.Reverse();
            for (int i = 0; i < ScoreList.Count; i++)
            {
                str += "Top " + (i + 1) + " : " + ScoreList[i].ToString() + "\n";
            }
        }
        catch (IOException e)
        {
            e.StackTrace.ToString();
        }
#endif
    }
}
