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

    private float vt;
    private float alpha = 30;
    private float t1, t2;
    private readonly float g = 9.8f;

    // Start is called before the first frame update
    void Start()
    {
        vt = SelectLevel.Instance.levelSelected.flyS;

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
        float cosa = Mathf.Cos(alpha * Mathf.PI / 180);
        float sina = Mathf.Sin(alpha * Mathf.PI / 180);
       
        float H = (vt * vt * sina * sina) / (2 * g);
        
        t1 = (vt * sina) / g;
        t2 = Mathf.Sqrt(2 * H  / g);

        float distance = vt * cosa * (t1 + t2);

        for (int i = 0; i < objectsPooling.Count; i++)
        {
            if (!objectsPooling[i].activeSelf)
            {
                objectsPooling[i].SetActive(true);
                objectsPooling[i].transform.position = new Vector3(1000 + distance, 0, 0) * x;
                x++;
                break;
            }
        }
    }
}
