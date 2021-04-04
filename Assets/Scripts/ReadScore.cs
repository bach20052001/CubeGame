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
        StreamReader reader = new StreamReader("Assets/Resources/Text/Score.txt");
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

#if UNITY_ANDROID && !UNITY_EDITOR
        try
        {
            TextAsset txtAsset = Resources.Load<TextAsset>("Text/Score");
            
            string txtContent = txtAsset.ToString() + "";
            
            File.WriteAllText(Application.persistentDataPath + "/Score.txt", txtContent, Encoding.UTF8);
            
            StreamReader theReader = new StreamReader(Application.persistentDataPath + "/Score.txt", Encoding.UTF8);
            
            string lineM;
            
            while ((lineM = theReader.ReadLine()) != null)
            {
                ScoreList.Add(Convert.ToInt32(lineM));
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
