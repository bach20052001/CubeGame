using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float _speedAward;
    private float _speed;
    private float grip;

    [SerializeField] private Score score;
    private LevelScriptable levelConfig;
    private PlayerCollision playerCollision;

    private float middleLine;

    private void Start()
    {
        levelConfig = SelectLevel.Instance.levelSelected;
        playerCollision = gameObject.GetComponent<PlayerCollision>();

        middleLine = Screen.width / 2;

        rb = GetComponent<Rigidbody>();

        _speedAward = levelConfig.speed;
        _speed = levelConfig.speedSide;
        grip = levelConfig.grip;
    }
    public void SetSpeedAward(float _speedAward)
    {
        this._speedAward = _speedAward;
    }

    public void SetSpeedSide(float _speed)
    {
        this._speed = _speed;
    }

    public int GetRealSpeed()
    {
        int speed = (int)rb.velocity.magnitude;
        return speed;
    }

    public float GetSpeed()
    {
        return _speedAward;
    }

    private void FixedUpdate()
    {
        rb.AddForce(_speedAward, 0, 0, ForceMode.Acceleration);

        #region MOBILE ENVIRONMENT
#if UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).position.x > middleLine)
            {
                //Right
                rb.AddForce(0, 0, -_speed * Time.deltaTime, ForceMode.VelocityChange);
            }
            else if (Input.GetTouch(0).position.x < middleLine)
            {
                //Left
                rb.AddForce(0, 0, _speed * Time.deltaTime, ForceMode.VelocityChange);
            }
        }
        else if (Input.touchCount == 2)
        {
            if (playerCollision.IsOnGround)
            {
                rb.AddForce(-grip * Time.deltaTime, 0, 0);
            }        
        }
#endif
#endregion

#region PC ENVIRONMENT     
#if UNITY_WEBGL || UNITY_STANDALONE

        if (Input.GetKey(KeyCode.Space))
        {
            //Brake
            if (playerCollision.IsOnGround)
            {
                rb.AddForce(-grip * Time.deltaTime, 0, 0);
            }
        }

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
            FindObjectOfType<GameManager>().GameOver();
        }
    }
#endif
#endregion
}

