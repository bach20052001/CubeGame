using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    private static SelectLevel instance;

    public static SelectLevel Instance
    {
        get
        {
            if (instance == null)
            {
                if (instance == null)
                {
                    GameObject selectLevel = new GameObject("Level Manager");
                    Instantiate(selectLevel);
                    SelectLevel _instance = selectLevel.AddComponent<SelectLevel>();
                    instance = _instance;
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject SelectGUI;
    [SerializeField] private GameObject GamePlay;
    [SerializeField] private GameObject pauseOrResume;

    public List<LevelScriptable> levels = new List<LevelScriptable>();
    public List<Button> levelButton = new List<Button>();

    [HideInInspector] public LevelScriptable levelSelected;

    private void Start()
    {
        for (int i = 0; i < levelButton.Count; i++)
        {
            int index = i;
            levelButton[i].onClick.AddListener(delegate { levelSelected = levels[index]; SetLevel(); });
        }
    }

    private void InitialGame()
    {
        GamePlay.SetActive(true);
        SelectGUI.SetActive(false);
        transform.gameObject.SetActive(true);
        pauseOrResume.SetActive(true);
    }

    public void SetLevel()
    {
        //Debug.Log(levelSelected.name);
        InitialGame();
        rb.drag = levelSelected.drag;
    }
}
