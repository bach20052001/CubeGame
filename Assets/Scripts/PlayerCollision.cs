using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement Player;
    private bool isOnGround;
    public bool IsOnGround
    {
        get
        {
            return isOnGround;
        }
    }

    private Vector3 GroundPos;
    private GameManager manager;

    private void Start()
    {
        Player = FindObjectOfType<PlayerMovement>();
        manager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacles"))
        {
            Player.enabled = false;
            manager.GameOver();
        }
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
        
        if (collision.gameObject.name == "Ground")
        {
            GroundPos = collision.gameObject.transform.position;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
    public Vector3 GetGroundPos()
    {
        return GroundPos;
    }
}
