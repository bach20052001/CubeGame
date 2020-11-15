using UnityEngine;

public class SetMode : MonoBehaviour
{
    public HorizonMove mode;
    public GameObject ButtonBraking;
#if (UNITY_IOS || UNITY_ANDROID)
    public void SetTouchScreen()
    {
        mode.SetIsTouch(true);
        ButtonBraking.SetActive(false);
    }
    public void SetTiltingDevice()
    {
        mode.SetIsTouch(false);
        ButtonBraking.SetActive(true);
    }
#endif
}
