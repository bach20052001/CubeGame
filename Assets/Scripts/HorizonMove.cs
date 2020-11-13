using UnityEngine;

public class HorizonMove : MonoBehaviour
{
	public Rigidbody rb;
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
	private bool isPressOne = false;
#endif
#if UNITY_IOS || UNITY_ANDROID
	private bool isOneFinger = false;
#endif

	private void Update()
	{
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
		if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1))
        {

			isPressOne = false;
			rb.transform.gameObject.GetComponent<Brake>().Braking();
		}
		else
        {
			if (Input.GetMouseButtonDown(0))
			{
				isPressOne = true;
			}
			if (Input.GetMouseButtonUp(0))
			{
				isPressOne = false;
			}
		}

		if (isPressOne)
        {
			if (Input.mousePosition.x < Screen.width / 2)
			{
				rb.AddForce(0, 0, 50f * Time.deltaTime, ForceMode.VelocityChange);
			}
			else
			{
				rb.AddForce(0, 0, -50f * Time.deltaTime, ForceMode.VelocityChange);
			}
		}
#endif
#if UNITY_IOS || UNITY_ANDROID
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
					rb.AddForce(0, 0, 50f * Time.deltaTime, ForceMode.VelocityChange);

				}
				else
				{
					rb.AddForce(0, 0, -50f * Time.deltaTime, ForceMode.VelocityChange);
				}
			}
		}
#endif
	}
}
