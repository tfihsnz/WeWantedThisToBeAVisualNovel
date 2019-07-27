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
    public int spriteNum;

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
        position = new Vector3(Random.Range(-5.7f, 5.0f), Random.Range(-0.2f, 2.0f), 0.0f);
        GameObject dinoPrefab = Resources.Load("iddleman") as GameObject;
        spriteNum = 1;
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
                dinoInstance = Instantiate(dinoPrefab, new Vector3(Random.Range(-5.7f, 5.0f), Random.Range(-0.2f, 2.0f), 0.0f), Quaternion.identity);
                dinoInstance.name = SpawnPrefab.name + spriteNum;
                SpawnClone.Add(dinoInstance);
                spriteNum++;
                //dinoInstance.transform.Translate(Random.Range(-5.7f, 5.0f), Random.Range(-0.2f, 2.0f), 0.0f);
            }
        }

        if (population < SpawnClone.Count)
        {
            Debug.Log("fuck");
            spriteNum--;
            GameObject.Destroy(SpawnClone[SpawnClone.Count - 1]);
            //SpawnClone.Remove(SpawnClone[SpawnClone.Count]);
            SpawnClone.RemoveAt(SpawnClone.Count - 1);
            SpawnClone.TrimExcess();
        }
    }
}
