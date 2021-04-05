using UnityEngine;

[CreateAssetMenu(fileName = "Level",menuName = "LevelConfiguration", order = 1)]
public class LevelScriptable : ScriptableObject
{
    public float drag;
    public float speedSide;
    public float speed;
    public float grip;
    public float flyS;
}
