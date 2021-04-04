using System.Collections;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    private PlayerMovement player;
    [SerializeField] private GameObject obstacles;
    [SerializeField] private GameObject grounds;
    [SerializeField] private GameObject bridges;
    [SerializeField] private GameManager gameManager;
    private float deltaTimeObstacle = 0.4f;
    private float deltaTimeBridge = 5f;
    private float deltaTimeGround = 20f;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerMovement>();
        StartCoroutine(Generate(obstacles, deltaTimeObstacle));
        StartCoroutine(Generate(bridges, deltaTimeBridge));
        StartCoroutine(GenerateG(grounds, deltaTimeGround));
    }

    IEnumerator Generate(GameObject temp, float timeInterval)
    {   
        while (!gameManager.IsOver)
        {
                temp.GetComponent<ObjectPooling>().GetObject();
                yield return new WaitForSeconds(timeInterval);
        }
    }
    IEnumerator GenerateG(GameObject temp, float timeInterval)
    {
        while (!gameManager.IsOver)
        {
            temp.GetComponent<ObjectPooling>().GetGround();
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
