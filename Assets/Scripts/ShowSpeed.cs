using UnityEngine;
using UnityEngine.UI;

public class ShowSpeed : MonoBehaviour
{
    private PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
       GetComponent<Text>().text = player.GetRealSpeed().ToString();    
    }
}
