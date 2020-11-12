using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement Player;
    public bool isOnGround;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacles"))
        {
            Player.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }
}
