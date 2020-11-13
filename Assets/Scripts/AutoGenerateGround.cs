using UnityEngine;

public class AutoGenerateGround : AutoGenerate
{
    public void SetTime(float Time)
    {
        this.Time = Time;
    }
    public override void Start()
    {
        Time = 20f;
        InvokeRepeating(nameof(UpdateAfterTimeSet), 0, Time);
    }
    public override void UpdateAfterTimeSet()
    {
        float side = base.SideSet();
        GameObject newGround = Instantiate(Object, new Vector3(player.transform.position.x + 1200, 0 + 50, side + 0), Quaternion.Euler(0, 0, 15));
        newGround.transform.parent = Objects.transform;
    }
}
