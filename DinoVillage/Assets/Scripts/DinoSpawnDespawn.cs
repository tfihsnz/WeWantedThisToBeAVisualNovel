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
    private GameObject dinoInstance;
    public GameObject dinoPrefab;

    public List<GameObject> SpawnClone = new List<GameObject>();

    //spawn pos
    public Vector3 position;

    void Awake()
    {
        //dinoInstance = Instantiate(dinoPrefab, position, Quaternion.identity);
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
            Debug.Log("ADD");
            for (int i = 1; population > SpawnClone.Count; i++)
            {  
                dinoInstance = Instantiate(dinoPrefab);
                dinoInstance.name = SpawnPrefab.name + i;
                SpawnClone.Add(dinoInstance);
                
            }
        }

        if (population <= SpawnClone.Count)
        {
            Debug.Log("fuck");
            GameObject.Destroy(SpawnClone[SpawnClone.Count - 1]);
            //SpawnClone.Remove(SpawnClone[SpawnClone.Count]);
            
            SpawnClone.Clear();
            //SpawnClone.TrimExcess();
            
        }
    }
}
