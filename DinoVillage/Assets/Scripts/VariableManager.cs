using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableManager : MonoBehaviour {

    //main variables
    public float population;
    public float unemployed;
    public float food;
    public float income;
    public float happiness;

    //time shit
    public float cycleTime = 0f;
    private float currentTime = 30f;

    //rate of increase and decrease
    public float foodRateD;
    public float foodRateI;
    public float incomeRateD;
    public float incomeRateI;
    public float happinessRateD;
    public float happinessRateI;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        currentTime -= Time.deltaTime;
        cycleTime += Time.deltaTime;

        if (cycleTime >= 5) {
            //update variables
            food = food + foodRateI;
            food = food - foodRateD;
            income = income + incomeRateI;
            income = income - incomeRateD;
            happiness = happiness + happinessRateI;
            happiness = happiness + happinessRateD;

            cycleTime = 0;
        }


        if (currentTime <= 0f) {
            //event!! yay omg yes amazing hurrah.
            Time.timeScale = 0;
            currentTime = 30f;
        }
    }
}
