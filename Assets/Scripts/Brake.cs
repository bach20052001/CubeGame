using UnityEngine;

public class Brake : MonoBehaviour
{
    public Rigidbody rb;
    private readonly float grip = 2500f;
    public GameObject NotiBrake;

    public void Braking()
    {
        bool isGround = rb.gameObject.GetComponent<PlayerCollision>().isOnGround;

        if (isGround)
        {
            NotiBrake.SetActive(true);
            rb.AddForce(-grip * Time.deltaTime, 0, 0);
        }
        else
        {
            NotiBrake.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        bool isGround = rb.gameObject.GetComponent<PlayerCollision>().isOnGround;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Space))
            {
            if (isGround)
            {
                NotiBrake.SetActive(true);
                rb.AddForce(-grip * Time.deltaTime, 0, 0);
            }
            else
            {
                NotiBrake.SetActive(false);
            }
        }
        else
        {
            NotiBrake.SetActive(false);
        }
    }
}
