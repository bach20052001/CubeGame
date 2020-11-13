using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveLeft : Button
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
            Left();
        }
    }

    protected override void Start()
    {
        rb = FindObjectOfType<PlayerMovement>().transform.gameObject.GetComponent<Rigidbody>();
    }

    private void Left()
    {
        rb.AddForce(0, 0, 50f * Time.deltaTime, ForceMode.VelocityChange);
    }
}
