using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveRight : Button
{
    private bool mouseDown;

    public Rigidbody rb;

    public override void OnPointerDown(PointerEventData eventData)
    {
        mouseDown = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        mouseDown = false;
    }

    private void Update()
    {
        if (mouseDown)
        {
            Right();
        }
    }
    protected override void Start()
    {
        rb = FindObjectOfType<PlayerMovement>().transform.gameObject.GetComponent<Rigidbody>();
    }
    private void Right()
    {
        rb.AddForce(0, 0, -50f * Time.deltaTime, ForceMode.VelocityChange);
    }
}
