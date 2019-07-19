using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableManager : MonoBehaviour
{

    //main variables
    public int population;
    public int unemployed;
    public int food;
    public int income;
    public int morale;

    //time shit
    public float cycleTime = 0f;
    private float currentTime = 30f;

    public int foodSpeed;

    // Start is called before the first frame update
    void Start()
    {
        foodSpeed = population/10;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        cycleTime += Time.deltaTime;

        if (cycleTime >= 5) {
            //do shit to variables

        }
        

        if (currentTime <= 0f) {
            //event!! yay omg yes amazing hurrah.
            Time.timeScale = 0;
            currentTime = 30f;
        }
    }
}
