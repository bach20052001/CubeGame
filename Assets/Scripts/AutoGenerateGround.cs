using UnityEngine;

public class AutoGenerateGround : AutoGenerate
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
    private void UpdateTime()
    {
        Time = 25f - score.GetScore() / 1000;
    }
    public override void Start()
    {
        Time = 25f;
        InvokeRepeating(nameof(UpdateAfterTimeSet), 0, Time);
    }

    public override void UpdateAfterTimeSet()
    {
        float PlayerPosition = player.transform.position.x;
        UpdateTime();
        GameObject newGround = Instantiate(Object, new Vector3(PlayerPosition + 1350 + score.GetScore() / 10 - (PlayerPosition % 1000), directionY, directionZ + 0), Quaternion.identity);
        newGround.transform.parent = Objects.transform;
    }
}
