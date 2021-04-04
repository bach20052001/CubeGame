using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private PlayerMovement TargetPlayer;

    private void Start()
    {
        TargetPlayer = FindObjectOfType<PlayerMovement>();
        offset = TargetPlayer.transform.position - transform.position;
    }

    private void LateUpdate()
    {
        transform.position = TargetPlayer.transform.position - offset;
    } 
}
