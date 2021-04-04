using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private float distance;
    private PlayerMovement player;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (player.transform.position.x - transform.position.x > distance)
        {
            gameObject.SetActive(false);
        }
    }
}
