using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement Player;
    public bool isOnGround;
    public Vector3 GroundPos;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacles"))
        {
            Player.GetComponent<PlayerMovement>().enabled = false;
            Player.transform.gameObject.GetComponent<Brake>().enabled = false;
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
        
        if (collision.gameObject.name == "Ground")
        {
            GroundPos = collision.gameObject.transform.position;
        }
    }
    public Vector3 GetGroundPos()
    {
        return GroundPos;
    }
}
