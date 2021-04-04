using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsPooling = new List<GameObject>();
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int amount;
    private Vector3 distance;
    private Vector3 prevDistance;
    private int x = 1;
    private PlayerMovement player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        distance = new Vector3(20, 0, 0);
        prevDistance = player.gameObject.transform.position;
        for (int i = 0; i < amount; i++)
        {
            GameObject pooling =  Instantiate(objectPrefab, Vector3.zero, objectPrefab.transform.rotation, gameObject.transform);
            pooling.SetActive(false);
            objectsPooling.Add(pooling);
        }
    }

    public void GetObject()
    {
        for (int i = 0; i < objectsPooling.Count; i++)
        {
            if (!objectsPooling[i].activeSelf)
            {
                objectsPooling[i].SetActive(true);
                objectsPooling[i].transform.position = distance + prevDistance + new Vector3(0, 0, Random.Range(-5f, 5f));
                prevDistance = new Vector3(objectsPooling[i].transform.position.x, objectsPooling[i].transform.position.y,0);
                break;
            }
        }
    }
    public void GetGround()
    {
        for (int i = 0; i < objectsPooling.Count; i++)
        {
            if (!objectsPooling[i].activeSelf)
            {
                objectsPooling[i].SetActive(true);
                objectsPooling[i].transform.position = new Vector3(1000, 0, 0) * x;
                x++;
                break;
            }
        }
    }
}
