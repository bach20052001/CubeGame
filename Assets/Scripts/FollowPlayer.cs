using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 Distance;
    public PlayerMovement TargetPlayer;
    // Start is called before the first frame update

    private void Start()
    {
        Distance = new Vector3(6.2f,
                       TargetPlayer.transform.position.y - transform.position.y,
                       0);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = TargetPlayer.transform.position - Distance;
    } 
}
