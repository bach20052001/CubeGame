using System;
using UnityEngine;

public class HorizonMove : MonoBehaviour
{
	public Rigidbody rb;


#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
	//private bool isPressOne = false;
	private float _speed = 60f;
#endif

#if (UNITY_IOS || UNITY_ANDROID)
	private bool isOneFinger = false;
	private bool IsTouch = true;
	private bool tiltingRight = false;
	private float _speed = 60f;
#endif
	public static HorizonMove instance;
	public static HorizonMove Instance {get{ return instance; }}
	
	public void SetSpeedTouch(float _speed)
    {
		this._speed = _speed;
    }

    private void Update()
	{
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
		//if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1))
  //      {

		//	isPressOne = false;
		//	rb.transform.gameObject.GetComponent<Brake>().Braking();
		//}
		//else
  //      {
		//	if (Input.GetMouseButtonDown(0))
		//	{
		//		isPressOne = true;
		//	}
		//	if (Input.GetMouseButtonUp(0))
		//	{
		//		isPressOne = false;
		//	}
		//}

		//if (isPressOne)
  //      {
		//	if (Input.mousePosition.x < Screen.width / 2)
		//	{
		//		rb.AddForce(0, 0, 75f * Time.deltaTime, ForceMode.VelocityChange);
		//	}
		//	else
		//	{
		//		rb.AddForce(0, 0, -75f * Time.deltaTime, ForceMode.VelocityChange);
		//	}
		//}
#endif

#if (UNITY_IOS || UNITY_ANDROID)
		if (IsTouch)
        {
			if (Input.touchCount > 0)
			{
			
				if (Input.touchCount == 2)
				{
					rb.transform.gameObject.GetComponent<Brake>().Braking();
					isOneFinger = false;
				}
				else
				{
					if (Input.touchCount == 1)
					{
						isOneFinger = true;
					}
				}

				if (isOneFinger)
				{
					Touch touch = Input.GetTouch(0);
					if (touch.position.x < Screen.width / 2)
					{
						rb.AddForce(0, 0, _speed * Time.deltaTime, ForceMode.VelocityChange);

					}
					else
					{
						rb.AddForce(0, 0, -_speed * Time.deltaTime, ForceMode.VelocityChange);
					}
				}
			}
        }
		else
		{
		if (Input.acceleration.x > 0)
			{
				tiltingRight = true;
			}
		else
			{
				tiltingRight = false;
			}

		if (tiltingRight)
			{
				rb.AddForce(0, 0, -_speed * Time.deltaTime * Math.Abs(Input.acceleration.x), ForceMode.VelocityChange);
			}
        else
			{
				rb.AddForce(0, 0, _speed * Time.deltaTime * Math.Abs(Input.acceleration.x), ForceMode.VelocityChange);
			}
		}
#endif
	}

#if (UNITY_IOS || UNITY_ANDROID)
	
	public void SetIsTouch(bool IsTouch)
	{
		this.IsTouch = IsTouch;
	}
#endif
}
