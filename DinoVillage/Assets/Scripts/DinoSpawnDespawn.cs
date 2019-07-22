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

    public List<GameObject> SpawnClone = new List<GameObject>();

    //spawn pos
    public Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        variableManager = gameObject.GetComponent<VariableManager>();
        position = new Vector3(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        population = variableManager.population;

        if (population > SpawnClone.Count)
        {
            for (int i = 1; population > SpawnClone.Count; i++)
            {
                SpawnClone.Add(SpawnPrefab);
                Instantiate(SpawnPrefab, position, Quaternion.identity);
            }
        }

        if (population < SpawnClone.Count)
        {
            Debug.Log("fuck");
            SpawnClone.Clear();
            SpawnClone.TrimExcess();
            Destroy(SpawnPrefab);
        }
    }
}
