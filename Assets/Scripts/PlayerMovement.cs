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

    //private Color32 RandomColor()
    //{
    //    int r = Random.Range(0, 255);
    //    int g = Random.Range(0, 255);
    //    int b = Random.Range(0, 255);
    //    Color32 res = new Color32((byte)r, (byte)g, (byte)b, 255);
    //    return res;
    //}

    private void FixedUpdate()
    {
        int AddSpeed = score.GetComponent<Score>().GetScore();
        
        //if (Input.GetKey(KeyCode.R))
        //{
        //    Debug.Log("Change Color");
        //    rb.transform.gameObject.GetComponent<Renderer>().material.color = RandomColor();

        //}

        rb.AddForce((_speedAward + AddSpeed / 2) * Time.deltaTime , 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.AddForce(0, 0, _speed * Time.deltaTime, ForceMode.VelocityChange);
        }

        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.AddForce(0, 0, -_speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        
        if (transform.position.y < GetComponent<PlayerCollision>().GetGroundPos().y)
        {
            rb.transform.gameObject.GetComponent<PlayerMovement>().enabled = false;
            rb.transform.gameObject.GetComponent<Brake>().enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}

