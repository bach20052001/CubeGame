using UnityEngine;

public class AutoGenarateObstacles : AutoGenerate
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
        // Update called per 'Time' second
        InvokeRepeating(nameof(UpdateAfterTimeSet), 0, Time);
    }
    public override void UpdateAfterTimeSet()
    {
        UpdateDirection();
        float side = SideSet();
        float temp;
        if (side > 0)
        {
            temp = -1.6f;
        }
        else
        {
            temp = 1.6f;
        }
        int n = (int)(score.GetScore()/500) + 1;
        
        if (n > 4) n = 4;

        n = Random.Range(1, n);
        for (int i = 0; i < n; i++)
        {
            GameObject newObstacles = Instantiate(Object, new Vector3(player.transform.position.x + 150 + i*i - 1, directionY, directionZ + side + i*temp + 0), Quaternion.identity);
            newObstacles.transform.parent = Objects.transform;
        }
    }
}
