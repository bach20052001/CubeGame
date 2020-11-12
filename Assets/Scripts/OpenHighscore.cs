using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHighscore : MonoBehaviour
{
    public GameObject HighScore;
    // Start is called before the first frame update
    public void Toggle()
    {
        Animator animator = HighScore.GetComponent<Animator>();
        bool isOpen = animator.GetBool("Open");
        animator.SetBool("Open",!isOpen);
    }
}
