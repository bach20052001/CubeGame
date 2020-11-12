using UnityEngine;

public class AutoGenarateObstacles : AutoGenerate
{
    public void SetTime(float Time)
    {
        this.Time = Time;
    }
    public override void Start()
    {
        // Update called per 'Time' second
        InvokeRepeating(nameof(UpdateAfterTimeSet), 0, Time);
    }
    public override void UpdateAfterTimeSet()
    {
        float side = SideSet();
        float temp;
        if (side > 0)
        {
            temp = -1.5f;
        }
        else
        {
            temp = 1.5f;
        }
        int n = (int)(score.GetScore()/500) + 1;

        for (int i = 0; i < n; i++)
        {
            GameObject newObstacles = Instantiate(Object, new Vector3(player.transform.position.x + 350 + i*i - 1, 0, side + i*temp + 0), Quaternion.identity);
            newObstacles.transform.parent = Objects.transform;
        }
    }
}
