﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizeObject : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject Obstacles;
    public GameObject Bridges;
    //public GameObject Grounds;
    void Update()
    {
        //Obstacles
        for (int i = 0; i < Obstacles.transform.childCount; i++)
        {
                if (player.transform.position.x - Obstacles.transform.GetChild(i).transform.position.x > 20)
                {
                    Destroy(Obstacles.transform.GetChild(i).gameObject);
                    break;
                }
        }
        //Bridges
        for (int i = 0; i < Bridges.transform.childCount; i++)
        {
            if (player.transform.position.x - Bridges.transform.GetChild(i).transform.position.x > 20)
            {
                Destroy(Bridges.transform.GetChild(i).gameObject);
                break;
            }
        }

        ////Grounds
        //for (int i = 0; i < Grounds.transform.childCount; i++)
        //{
        //    if (player.transform.position.x - Grounds.transform.GetChild(i).transform.position.x > 600)
        //    {
        //        Destroy(Grounds.transform.GetChild(i).gameObject);
        //        break;
        //    }
        //}
    }
}
