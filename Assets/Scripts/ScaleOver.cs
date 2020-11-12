using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOver : MonoBehaviour
{
    public PlayerMovement Player;
    public float PlayTime = 0;
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x + Player.GetSpeed() * Time.deltaTime / 5,
                                           transform.localScale.y,
                                           transform.localScale.z);

        transform.position = new Vector3(transform.position.x + Player.GetSpeed() * Time.deltaTime / 11,
                                        0,
                                        0);
    }
}
