using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSpawnDespawn : MonoBehaviour {

    //get variablemanager
    public GameObject gameObject;
    public int population = 0;
    public VariableManager variableManager;

    //sprite creation
    public GameObject SpawnPrefab;
    GameObject dinoInstance;
    public GameObject dinoPrefab;

    public List<GameObject> SpawnClone = new List<GameObject>();

    //spawn pos
    public Vector3 position;

    void Awake()
    {
        dinoInstance = Instantiate(dinoPrefab, position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        variableManager = gameObject.GetComponent<VariableManager>();
        position = new Vector3(0.0f, 0.0f, 0.0f);
        GameObject dinoPrefab = Resources.Load("iddleman") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        population = variableManager.population;

        if (population > SpawnClone.Count)
        {
            for (int i = 1; population > SpawnClone.Count; i++)
            {
                SpawnClone.Add(dinoPrefab);
                Instantiate(dinoInstance);
                dinoInstance.name = SpawnPrefab.name + i;
            }
        }

        if (population < SpawnClone.Count)
        {
            Debug.Log("fuck");
            SpawnClone.Clear();
            //SpawnClone.TrimExcess();
            GameObject.Destroy(dinoInstance);
        }
    }
}
