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
    //public float happiness;
    //public Text happinessText;

    //job variables
    public int hunting;
    public int huntingCap;
    public Text huntingText;
    public int mining;
    public int miningCap;
    public Text miningText;
    //public int performance;
    //public Text performanceText;
    public int scouting;
    public int scoutingCap;
    public Text scoutingText;


    //time shit
    public float cycleTime = 0f;
    private float currentTime = 30f;

    //rate of increase and decrease
    public float foodRateD;
    public float foodRateI;
    public float incomeRateD;
    public float incomeRateI;
    //public float happinessRateD;
    //public float happinessRateI;

    public int popCounter = 0;

    // Start is called before the first frame update
    void Start() {
        population = 10;
        unemployed = population;
        food = 10;
        income = 10;
        unemployed = 0;
        huntingCap = 5;
        miningCap = 5;
        scoutingCap = 5;
        //happiness = 5;
    }

    // Update is called once per frame
    void Update() {
        currentTime -= Time.deltaTime;
        cycleTime += Time.deltaTime;

        //text updates
        populationText.text = "Population: " + population.ToString("00");
        foodText.text = "Food: " + food.ToString("00");
        incomeText.text = "Income: " + income.ToString("00");
        unemployedText.text = "Unemployed: " + unemployed.ToString("00");
        //happinessText.text = "Happiness: " + happiness.ToString("00");
        huntingText.text = hunting.ToString("00");
        miningText.text = mining.ToString("00");

        foodRateD = (population * 0.09f + 8) / 10;
        foodRateI = (hunting * 1.9f);
        incomeRateD = (mining * 0.09f + 8) / 10;
        incomeRateI = (mining * 1.9f);

        if (cycleTime >= 3) {
            //update variables
            food = food + foodRateI;
            food = food - foodRateD;
            income = income + incomeRateI;
            income = income - incomeRateD;
            //happiness = happiness + happinessRateI;
            //happiness = happiness - happinessRateD;

            cycleTime = 0;
        }


        if (currentTime <= 0f) {
            //event!! yay omg yes amazing hurrah.
            Time.timeScale = 0;
            popCounter++;
            currentTime = 30f;
        }

        if (popCounter == 2) {
            population++;
            popCounter = 0;
        }
    }

    public void IncreaseHunting() {
        if (population > 0 && hunting < huntingCap) {
            hunting++;
            population--;
            unemployed--;
        }
    }

    public void IncreaseHunting5() {
        if (population > 4 && (huntingCap - hunting) > 4) {
            hunting = hunting + 5;
            population = population - 5;
            unemployed = unemployed - 5;
        } else if (population > 3 && (huntingCap - hunting) == 4) {
            hunting = hunting + 4;
            population = population - 4;
            unemployed = unemployed - 4;
        } else if (population > 2 && (huntingCap - hunting) == 3) {
            hunting = hunting + 3;
            population = population - 3;
            unemployed = unemployed - 3;
        } else if (population > 1 && (huntingCap - hunting) == 2) {
            hunting = hunting + 2;
            population = population - 2;
            unemployed = unemployed - 2;
        } else if (population > 0 && (huntingCap - hunting) == 1) {
            hunting = hunting + 1;
            population = population - 1;
            unemployed = unemployed - 1;
        }
    }

    public void DecreaseHunting() {
        if (hunting > 0) {
            hunting--;
            population++;
            unemployed++;
        }
    }

    public void DecreaseHunting5() {
        if (hunting > 0) {
            if (hunting > 4) {
                hunting = hunting - 5;
                population = population + 5;
                unemployed = unemployed + 5;
            } else if (hunting == 4) {
                hunting = hunting - 4;
                population = population + 4;
                unemployed = unemployed + 4;
            } else if (hunting == 3) {
                hunting = hunting - 3;
                population = population + 3;
                unemployed = unemployed + 3;
            } else if (hunting == 2) {
                hunting = hunting - 2;
                population = population + 2;
                unemployed = unemployed + 2;
            } else if (hunting == 1) {
                hunting = hunting - 1;
                population = population + 1;
                unemployed = unemployed + 1;
            }
        }
    }

    
}
