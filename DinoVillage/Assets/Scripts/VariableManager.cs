using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableManager : MonoBehaviour {

    //main variables
    public int population;
    public Text populationText;
    public float unemployed;
    public Text unemployedText;
    public float food;
    public Text foodText;
    public float income;
    public Text incomeText;
    public float happiness;
    public Text happinessText;

    //job variables
    public int hunting;
    public Text huntingText;
    public int mining;
    public Text miningText;
    public int performance;
    public Text performanceText;
    public int scouting;
    public Text scoutingText;


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
        population = 10;
        food = 10;
        income = 10;
        happiness = 5;
    }

    // Update is called once per frame
    void Update() {
        currentTime -= Time.deltaTime;
        cycleTime += Time.deltaTime;

        //text updates
        populationText.text = "Population: " + population.ToString("00");
        foodText.text = "Food: " + food.ToString("00");
        incomeText.text = "Income: " + income.ToString("00");
        happinessText.text = "Happiness: " + happiness.ToString("00");

        foodRateD = (population * 0.09 + 8) / 10;
        foodRateI = 

        if (cycleTime >= 3) {
            //update variables
            food = food + foodRateI;
            food = food - foodRateD;
            income = income + incomeRateI;
            income = income - incomeRateD;
            happiness = happiness + happinessRateI;
            happiness = happiness - happinessRateD;

            cycleTime = 0;
        }


        if (currentTime <= 0f) {
            //event!! yay omg yes amazing hurrah.
            Time.timeScale = 0;
            currentTime = 30f;
        }
    }
}
