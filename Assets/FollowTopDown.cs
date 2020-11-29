using UnityEngine;

public class FollowTopDown : MonoBehaviour
{
    private float Distance;
    public PlayerMovement TargetPlayer;
    // Start is called before the first frame update

    private void Start()
    {
        Distance = TargetPlayer.transform.position.x - transform.position.x;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(TargetPlayer.transform.position.x - Distance, transform.position.y, transform.position.z);
    }
}
