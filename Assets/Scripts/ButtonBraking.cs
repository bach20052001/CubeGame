using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonBraking : Button
{
    private bool mouseDown;

    public GameObject player;

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
            player.GetComponent<Brake>().Braking();
        }
    }
    protected override void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform.gameObject;
    }
}
