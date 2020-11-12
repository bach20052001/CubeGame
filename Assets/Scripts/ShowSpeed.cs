using UnityEngine;
using UnityEngine.UI;

public class ShowSpeed : MonoBehaviour
{
    public PlayerMovement player;

    // Update is called once per frame
    void Update()
    {
       GetComponent<Text>().text = player.GetRealSpeed().ToString();    
    }
}
