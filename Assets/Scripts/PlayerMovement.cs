using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float _speedAward = 2500f;
    public float _speed = 75f;
    public Score score;
    
    private void Start()
    {
        _speedAward = 2500f;
        _speed = 75f;
    }
    public void SetSpeedAward(float _speedAward) {
        this._speedAward = _speedAward;
    }

    public void SetSpeedSide(float _speed)
    {
        this._speed = _speed;
    }

    public int GetRealSpeed()
    {
        int speed =  (int)rb.velocity.magnitude;
        return speed;
    }

    public float GetSpeed()
    {
        return _speedAward;
    }

    private void FixedUpdate()
    {
        int AddSpeed = score.GetComponent<Score>().GetScore();
        //if (AddSpeed > 1000) rb.transform.gameObject.GetComponent<Renderer>().material.color = (Color.green);
        rb.AddForce((_speedAward + AddSpeed) * Time.deltaTime , 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.AddForce(0, 0, _speed * Time.deltaTime, ForceMode.VelocityChange);
        }

        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.AddForce(0, 0, -_speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        
        if (transform.position.y < 0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}

