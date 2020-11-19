using UnityEngine;

public class AutoGenerateBridge : AutoGenerate
{
    private float directionZ;
    private float directionY;

    public void SetTime(float Time)
    {
        this.Time = Time;
    }

    public void UpdateDirection()
    {
        directionZ = playerr.GetGroundPos().z;
        directionY = playerr.GetGroundPos().y;
    }

    public override void Start()
    {
        InvokeRepeating(nameof(UpdateAfterTimeSet), 0, Time);
        UpdateDirection();
    }
    public override void UpdateAfterTimeSet()
    {
        UpdateDirection();
        float side =  SideSet();
        GameObject newObstacles = Instantiate(Object, new Vector3(player.transform.position.x + 750, directionY + 1, directionZ + side + 0),Quaternion.Euler(0,0,15));
        newObstacles.transform.parent = Objects.transform;
    }
}
