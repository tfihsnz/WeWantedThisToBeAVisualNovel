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
    public Text huntingCapText;
    public int mining;
    public int miningCap;
    public Text miningText;
    public Text miningCapText;
    //public int performance;
    //public Text performanceText;
    public int scouting;
    public int scoutingCap;
    public Text scoutingText;
    public Text scoutingCapText;


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
        unemployed = 10;
        food = 10;
        income = 10;
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
        huntingCapText.text = huntingCap.ToString("00");
        miningText.text = mining.ToString("00");
        miningCapText.text = miningCap.ToString("00");
        scoutingText.text = scouting.ToString("00");
        scoutingCapText.text = scoutingCap.ToString("00");

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
        if (unemployed > 0 && hunting < huntingCap) {
            hunting++;
            unemployed--;
        }
    }

    public void IncreaseHunting5() {
        if (unemployed > 4 && (huntingCap - hunting) > 4) {
            hunting = hunting + 5;
            unemployed = unemployed - 5;
        } else if (unemployed > 3 && (huntingCap - hunting) == 4) {
            hunting = hunting + 4;
            unemployed = unemployed - 4;
        } else if (unemployed > 2 && (huntingCap - hunting) == 3) {
            hunting = hunting + 3;
            unemployed = unemployed - 3;
        } else if (unemployed > 1 && (huntingCap - hunting) == 2) {
            hunting = hunting + 2;
            unemployed = unemployed - 2;
        } else if (unemployed > 0 && (huntingCap - hunting) == 1) {
            hunting = hunting + 1;
            unemployed = unemployed - 1;
        }
    }

    public void DecreaseHunting() {
        if (hunting > 0) {
            hunting--;
            unemployed++;
        }
    }

    public void DecreaseHunting5() {
        if (hunting > 0) {
            if (hunting > 4) {
                hunting = hunting - 5;
                unemployed = unemployed + 5;
            } else if (hunting == 4) {
                hunting = hunting - 4;
                unemployed = unemployed + 4;
            } else if (hunting == 3) {
                hunting = hunting - 3;
                unemployed = unemployed + 3;
            } else if (hunting == 2) {
                hunting = hunting - 2;
                unemployed = unemployed + 2;
            } else if (hunting == 1) {
                hunting = hunting - 1;
                unemployed = unemployed + 1;
            }
        }
    }

    public void IncreaseMining() {
        if (unemployed > 0 && mining < miningCap) {
            mining++;
            unemployed--;
        }
    }

    public void IncreaseMining5() {
        if (unemployed > 4 && (miningCap - mining) > 4) {
            mining = mining + 5;
            unemployed = unemployed - 5;
        } else if (unemployed > 3 && (miningCap - mining) == 4) {
            mining = mining + 4;
            unemployed = unemployed - 4;
        } else if (unemployed > 2 && (miningCap - mining) == 3) {
            mining = mining + 3;
            unemployed = unemployed - 3;
        } else if (unemployed > 1 && (miningCap - mining) == 2) {
            mining = mining + 2;
            unemployed = unemployed - 2;
        } else if (unemployed > 0 && (miningCap - mining) == 1) {
            mining = mining + 1;
            unemployed = unemployed - 1;
        }
    }

    public void DecreaseMining() {
        if (mining > 0) {
            mining--;
            unemployed++;
        }
    }

    public void DecreaseMining5() {
        if (mining > 0) {
            if (mining > 4) {
                mining = mining - 5;
                unemployed = unemployed + 5;
            } else if (mining == 4) {
                mining = mining - 4;
                unemployed = unemployed + 4;
            } else if (mining == 3) {
                mining = mining - 3;
                unemployed = unemployed + 3;
            } else if (mining == 2) {
                mining = mining - 2;
                unemployed = unemployed + 2;
            } else if (mining == 1) {
                mining = mining - 1;
                unemployed = unemployed + 1;
            }
        }
    }

    public void IncreaseScouting() {
        if (unemployed > 0 && scouting < scoutingCap) {
            scouting++;
            unemployed--;
        }
    }

    public void IncreaseScouting5() {
        if (unemployed > 4 && (scoutingCap - scouting) > 4) {
            scouting = scouting + 5;
            unemployed = unemployed - 5;
        } else if (unemployed > 3 && (scoutingCap - scouting) == 4) {
            scouting = scouting + 4;
            unemployed = unemployed - 4;
        } else if (unemployed > 2 && (scoutingCap - scouting) == 3) {
            scouting = scouting + 3;
            unemployed = unemployed - 3;
        } else if (unemployed > 1 && (scoutingCap - scouting) == 2) {
            scouting = scouting + 2;
            unemployed = unemployed - 2;
        } else if (unemployed > 0 && (scoutingCap - scouting) == 1) {
            scouting = scouting + 1;
            unemployed = unemployed - 1;
        }
    }

    public void DecreaseScouting() {
        if (scouting > 0) {
            scouting--;
            unemployed++;
        }
    }

    public void DecreaseScouting5() {
        if (scouting > 0) {
            if (scouting > 4) {
                scouting = scouting - 5;
                unemployed = unemployed + 5;
            } else if (scouting == 4) {
                scouting = scouting - 4;
                unemployed = unemployed + 4;
            } else if (scouting == 3) {
                scouting = scouting - 3;
                unemployed = unemployed + 3;
            } else if (scouting == 2) {
                scouting = scouting - 2;
                unemployed = unemployed + 2;
            } else if (scouting == 1) {
                scouting = scouting - 1;
                unemployed = unemployed + 1;
            }
        }
    }

}
