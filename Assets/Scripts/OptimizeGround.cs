using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizeGround : MonoBehaviour
{
    public GameObject Ground;
    public PlayerMovement player;
    // Update is called once per frame
    void Update()
    {
        Ground.transform.position = new Vector3(player.transform.position.x + 490,
                                                Ground.transform.position.y,
                                                Ground.transform.position.z);
    }
}
