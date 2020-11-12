using UnityEngine;

public class AutoGenerateBridge : AutoGenerate
{
    public override void Start()
    {
        Time = 10f;
        // Update called per 'Time' second
        InvokeRepeating(nameof(UpdateAfterTimeSet), 0, Time);
    }
    public override void UpdateAfterTimeSet()
    {
        float side =  base.SideSet();
        GameObject newObstacles = Instantiate(Object, new Vector3(player.transform.position.x + 750, 0 + 1, side + 0),Quaternion.Euler(0,0,15));
        newObstacles.transform.parent = Objects.transform;
    }
}
