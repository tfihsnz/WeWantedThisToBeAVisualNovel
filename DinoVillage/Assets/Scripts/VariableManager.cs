using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableManager : MonoBehaviour {

    //main variables
    public int population;
    public Text populationText;
    public int unemployed;
    public Text unemployedText;
    public int food;
    public Text foodText;
    public int income;
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
    public int cycleRounds = 0;

    //rate of increase and decrease
    public int foodRateD;
    public int foodRateI;
    public int incomeRateD;
    public int incomeRateI;
    //public float happinessRateD;
    //public float happinessRateI;
    public int populationRateI;

    public int upgHuntingCount;
    public int upgMiningCount;
    public int upgScoutingCount;
    public int upgCost;
    
    public Text upgHuntingText;
    public Text upgMiningText;
    public Text upgScoutingText;

    public int popCounter = 0;

    //event bools
    private bool orbEvent;
    private bool weaponsEvent;
    private bool itemEvent;
    private bool orbReceived;
    private bool itemReceived;
    private bool weaponsReceived;
    private bool rottenFoodReceived;
    private bool huntingReward;
    private bool huntingAccident;
    private bool miningReward;
    private bool miningAccident;
    private bool zombieEvent;
    private bool rottenFoodEvent;
    private bool merchantEvent;
    private bool invasionEvent;
    private bool coupEvent;
    private bool skeletonEvent;
    private bool mageEvent;
    private bool cultEvent;
    private bool godEvent;
    private bool meteorEvent;
    private bool mageAccepted;
    private bool orbOff;
    private bool weaponsOff;
    private bool itemOff;

    //event texts
    public Text titleChoice;
    public Text titleMain;
    public Text bodyChoice;
    public Text bodyMain;
    public Text leftChoice;
    public Text rightChoice;

    public GameObject choiceCanvas;
    public GameObject eventCanvas;

    public class MainEvents {
        public string eventName;

        public MainEvents(string newEventName) {
            eventName = newEventName;
        }
    }

    //public List<MainEvents> mainEvents = new List<MainEvents>();

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
        upgCost = 30;
        upgHuntingCount = 1;
        upgMiningCount = 1;
        upgScoutingCount = 1;
        
        //mainEvents.Add(new MainEvents("Zombie"));
        //mainEvents.Add(new MainEvents("RottenFood"));
        //mainEvents.Add(new MainEvents("Merchant"));
        //mainEvents.Add(new MainEvents("Invasion"));
        //mainEvents.Add(new MainEvents("Coup"));
        //mainEvents.Add(new MainEvents("Skeleton"));
        //mainEvents.Add(new MainEvents("Mage"));
        //mainEvents.Add(new MainEvents("Cult"));
        //mainEvents.Add(new MainEvents("God"));
    }

    // Update is called once per frame
    void Update() {
        currentTime -= Time.deltaTime;
        cycleTime += Time.deltaTime;

        if (population < (unemployed + hunting + mining + scouting)) {
            if (unemployed > 0) {
                unemployed--;
            } else if (scouting > 0) {
                scouting--;
            } else if (hunting > 0) {
                hunting--;
            } else if (mining > 0) {
                mining--;
            }
        }

        unemployed = population - hunting - mining - scouting;

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

        foodRateD = Mathf.RoundToInt((population * 0.09f + 8) / 10) + 1;
        if (hunting > 0) {
            foodRateI = Mathf.RoundToInt((hunting * 0.25f)) + 2;
        }        
        incomeRateD = Mathf.RoundToInt((mining * 0.09f + 8) / 10) + 1;
        if (income > 0) {
            incomeRateI = Mathf.RoundToInt((mining * 0.25f)) + 2;
        }
        if (scouting > 0) {
            populationRateI = Mathf.RoundToInt((scouting * 0.25f)) + 1;
        }        

        upgHuntingText.text = (30 * upgHuntingCount).ToString("00");
        upgMiningText.text = (30 * upgMiningCount).ToString("00");
        upgScoutingText.text = (30 * upgScoutingCount).ToString("00");

        /*if (orbReceived && rottenFoodReceived) {
            mainEvents.Add(new MainEvents("Zombie"));
            orbReceived = false;
        }*/

        if (cycleTime >= 3) {
            //update variables
            food += foodRateI;
            food -= foodRateD;
            income += incomeRateI;
            income -= incomeRateD;
            //happiness = happiness + happinessRateI;
            //happiness = happiness - happinessRateD;
            int c = Random.Range(1, 10);
            if (c < 2) {
                population += populationRateI;
            }            

            if (food <= 0) {
                population = population - 10;
            }

            if (income <= 0) {
                population = population - 5;
                food = food - 5;
            }

            int i = Random.Range(1, 100);

            if (i < 6) {
                //job event
                int k = Random.Range(1, 200);

                if (k <= 100 && hunting > 0) {
                    //hunting event
                    if (k <= 20) {
                        huntingReward = true;
                        EventTextbox();
                        food += Mathf.RoundToInt(25 + ((15/100)*food));
                    } else if (k <= 40) {
                        huntingAccident = true;
                        EventTextbox();
                        int huntingTemp;
                        huntingTemp = Mathf.RoundToInt(hunting/4);
                        hunting -= huntingTemp;
                        population -= huntingTemp;
                    }
                } else if (k <= 200 && mining > 0) {
                    //mining event
                    if (k <= 120) {
                        miningReward = true;
                        EventTextbox();
                        income += Mathf.RoundToInt(25 + ((15 / 100) * income));
                    } else if (k <= 140) {
                        miningAccident = true;
                        EventTextbox();
                        int miningTemp;
                        miningTemp = Mathf.RoundToInt(mining / 4);
                        mining -= miningTemp;
                        population -= miningTemp;
                    }
                }
            } 

            cycleTime = 0;
        }


        if (currentTime <= 0f) {
            //event!! yay omg yes amazing hurrah.
            //Time.timeScale = 0;
            int b = Random.Range(1, 100);

            if (orbReceived && rottenFoodReceived) {
                if (b <= 20) {
                    //zombie apocalypse
                    zombieEvent = true;
                    population -= Mathf.RoundToInt(population / 5);
                } else if (b <= 40) {
                    //mage
                    mageEvent = true;
                } else if (b <= 60) {
                    //merchant
                    merchantEvent = true;
                    if (itemReceived) {
                        income += Random.Range(30, 50);
                    } else {
                        income += Random.Range(10, 30);
                    }
                } else if (b <= 80) {
                    //invasion
                    invasionEvent = true;
                    population -= Mathf.RoundToInt(population * 0.4f);
                } else if (b <= 99) {
                    //coup d'etat
                    coupEvent = true;
                    population -= Mathf.RoundToInt(population * 0.35f);
                    food -= Mathf.RoundToInt(food * 0.35f);
                    income -= Mathf.RoundToInt(income * 0.35f);
                } else if (b == 100) {
                    //meteorite
                    meteorEvent = true;
                }
            } else if (mageAccepted && orbReceived && rottenFoodReceived) {
                if (b <= 20) {
                    //zombie apocalypse
                    zombieEvent = true;
                    population -= Mathf.RoundToInt(population / 5);
                } else if (b <= 40) {
                    //rotten food
                    rottenFoodEvent = true;
                    food -= Mathf.RoundToInt(food * 0.4f);
                } else if (b <= 60) {
                    //skeleton
                    skeletonEvent = true;
                    population -= Mathf.RoundToInt(population * 0.4f);
                } else if (b <= 80) {
                    //cult
                    cultEvent = true;
                    population -= Mathf.RoundToInt(population * 0.4f);
                    food -= Mathf.RoundToInt(food * 0.3f);
                } else if (b <= 99) {
                    //god                    
                    godEvent = true;
                    population -= Mathf.RoundToInt(population * 0.5f);
                    food -= Mathf.RoundToInt(food * 0.5f);
                    income -= Mathf.RoundToInt(income * 0.5f);
                } else if (b == 100) {
                    //meteorite
                    meteorEvent = true;
                }
            } else if (mageAccepted) {
                if (b <= 20) {
                    //merchant
                    merchantEvent = true;
                    if (itemReceived) {
                        income += Random.Range(30, 50);
                    } else {
                        income += Random.Range(10, 30);
                    }
                } else if (b <= 40) {
                    //rotten food
                    rottenFoodEvent = true;
                    food -= Mathf.RoundToInt(food * 0.4f);
                } else if (b <= 60) {
                    //skeleton
                    skeletonEvent = true;
                    population -= Mathf.RoundToInt(population * 0.4f);
                } else if (b <= 80) {
                    //cult
                    cultEvent = true;
                    population -= Mathf.RoundToInt(population * 0.4f);
                    food -= Mathf.RoundToInt(food * 0.3f);
                } else if (b <= 99) {
                    //god
                    godEvent = true;
                    population -= Mathf.RoundToInt(population * 0.5f);
                    food -= Mathf.RoundToInt(food * 0.5f);
                    income -= Mathf.RoundToInt(income * 0.5f);
                } else if (b == 100) {
                    //meteorite
                    meteorEvent = true;
                }
            } else {
                if (b <= 25) {
                    //rotten food
                    rottenFoodEvent = true;
                    food -= Mathf.RoundToInt(food * 0.4f);
                } else if (b <= 50) {
                    //merchant
                    merchantEvent = true;
                    if (itemReceived) {
                        income += Random.Range(30, 50);
                    } else {
                        income += Random.Range(10, 30);
                    }
                } else if (b <= 75) {
                    //mage
                    mageEvent = true;
                } else if (b <= 99) {
                    //coup d'etat
                    coupEvent = true;
                    population -= Mathf.RoundToInt(population * 0.35f);
                    food -= Mathf.RoundToInt(food * 0.35f);
                    income -= Mathf.RoundToInt(income * 0.35f);
                } else if (b == 100) {
                    //meteorite
                    meteorEvent = true;
                }
            }

            EventTextbox();

            popCounter++;
            currentTime = 30f;
            cycleRounds++;
            Time.timeScale = 0;
        }

        if (popCounter == 2) {
            population++;
            unemployed++;

            //scouting events
            int a = Random.Range(1, 300);

            if (a <= 10) {
                //orb event
                if (orbOff) {
                    orbEvent = true;
                    EventTextbox();
                    orbOff = true;
                    Time.timeScale = 0;
                }                
            } else if (a <= 20) {
                //weapons event
                if (weaponsOff) {
                    weaponsEvent = true;
                    EventTextbox();
                    weaponsOff = true;
                    Time.timeScale = 0;
                }
            } else if (a < 30) {
                //merchant item
                if (itemOff) {
                    itemEvent = true;
                    EventTextbox();
                    itemOff = true;
                }
            }

            popCounter = 0;
        }

        if (population <= 0) {
            //Game Over;
            population = 0;
            Time.timeScale = 0;
        }

        if (food <= 0) {
            food = 0;
        }

        if (income <= 0) {
            income = 0;
        }

        if (unemployed <= 0) {
            unemployed = 0;
        }
    }

    public void IncreaseHunting() {
        if (unemployed > 0 && hunting < huntingCap) {
            hunting++;
            unemployed--;
        }
    }

    public void IncreaseHunting5() {
        /*if (unemployed > 4 && huntingCap - hunting > 4) {
            hunting = hunting + 5;
            unemployed = unemployed - 5;
        } else if (unemployed > 3 && huntingCap - hunting == 4) {
            hunting = hunting + 4;
            unemployed = unemployed - 4;
        } else if (unemployed > 2 && huntingCap - hunting == 3) {
            hunting = hunting + 3;
            unemployed = unemployed - 3;
        } else if (unemployed > 1 && huntingCap - hunting == 2) {
            hunting = hunting + 2;
            unemployed = unemployed - 2;
        } else if (unemployed > 0 && huntingCap - hunting == 1) {
            hunting = hunting + 1;
            unemployed = unemployed - 1;
        } else if (unemployed == 1 && huntingCap - hunting > 0) {
            hunting = hunting + 1;
            unemployed = unemployed - 1;
        } else if (unemployed == 2 && huntingCap - hunting > 1) {
            hunting = hunting + 2;
            unemployed = unemployed - 2;
        } else if (unemployed == 3 && huntingCap - hunting > 2) {
            hunting = hunting + 3;
            unemployed = unemployed - 3;
        } else if (unemployed == 4 && huntingCap - hunting > 3) {
            hunting = hunting + 4;
            unemployed = unemployed - 4;
        }
        IncreaseHunting();
        IncreaseHunting();
        IncreaseHunting();
        IncreaseHunting();
        IncreaseHunting();*/

        if (unemployed > (huntingCap - hunting)) {
            if ((unemployed - (unemployed - (huntingCap - hunting)) >= 5)) {
                hunting += 5;
            } else {
                hunting += unemployed - (unemployed - (huntingCap - hunting));
            }
        } else if (unemployed < (huntingCap - hunting) || unemployed == (huntingCap - hunting)) {
            if ((unemployed - (unemployed - (huntingCap - hunting)) >= 5)) {
                hunting += 5;
            } else {
                hunting += unemployed;
            }                
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
        /*if (unemployed > 4 && (miningCap - mining) > 4) {
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
        } else if (unemployed == 1 && (miningCap - mining) > 0) {
            mining = mining + 1;
            unemployed = unemployed - 1;
        } else if (unemployed == 2 && (miningCap - mining) > 1) {
            mining = mining + 2;
            unemployed = unemployed - 2;
        } else if (unemployed == 3 && (miningCap - mining) > 2) {
            mining = mining + 3;
            unemployed = unemployed - 3;
        } else if (unemployed == 4 && (miningCap - mining) > 3) {
            mining = mining + 4;
            unemployed = unemployed - 4;
        }
        IncreaseMining();
        IncreaseMining();
        IncreaseMining();
        IncreaseMining();
        IncreaseMining();*/

        if (unemployed > (miningCap - mining)) {
            if ((unemployed - (unemployed - (miningCap - mining)) >= 5)) {
                mining += 5;
            } else {
                mining += unemployed - (unemployed - (miningCap - mining));
            }
        } else if (unemployed < (miningCap - mining) || unemployed == (miningCap - mining)) {
            if ((unemployed - (unemployed - (miningCap - mining)) >= 5)) {
                mining += 5;
            } else {
                mining += unemployed;
            }
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
        /*if (unemployed > 4 && (scoutingCap - scouting) > 4) {
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
        } else if (unemployed == 1 && (scoutingCap - scouting) > 0) {
            scouting = scouting + 1;
            unemployed = unemployed - 1;
        } else if (unemployed == 2 && (scoutingCap - scouting) > 1) {
            scouting = scouting + 2;
            unemployed = unemployed - 2;
        } else if (unemployed == 3 && (scoutingCap - scouting) > 2) {
            scouting = scouting + 3;
            unemployed = unemployed - 3;
        } else if (unemployed == 4 && (scoutingCap - scouting) > 3) {
            scouting = scouting + 4;
            unemployed = unemployed - 4;
        }
        IncreaseScouting();
        IncreaseScouting();
        IncreaseScouting();
        IncreaseScouting();
        IncreaseScouting();*/

        if (unemployed > (scoutingCap - scouting)) {
            if ((unemployed - (unemployed - (scoutingCap - scouting)) >= 5)) {
                scouting += 5;
            } else {
                scouting += unemployed - (unemployed - (scoutingCap - scouting));
            }
        } else if (unemployed < (scoutingCap - scouting) || unemployed == (scoutingCap - scouting)) {
            if ((unemployed - (unemployed - (scoutingCap - scouting)) >= 5)) {
                scouting += 5;
            } else {
                scouting += unemployed;
            }
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

    public void UpgradeHunting() {
        if (income > (30 * upgHuntingCount)) {
            income = income - (30 * upgHuntingCount);
            upgHuntingCount++;
            huntingCap = huntingCap + 5;
        }
    }

    public void UpgradeMining() {
        if (income > (30 * upgMiningCount)) {
            income = income - (30 * upgMiningCount);
            upgMiningCount++;
            miningCap = miningCap + 5;
        }
    }

    public void UpgradeScouting() {
        if (income > (30 * upgScoutingCount)) {
            income = income - (30 * upgScoutingCount);
            upgScoutingCount++;
            scoutingCap = scoutingCap + 5;
        }
    }

    public void EventTextbox() {
        //ffs
        if (huntingReward) {
            eventCanvas.SetActive(true);
            titleMain.text = "Hunting Reward";
            bodyMain.text = "The dinos found a big herd of humies. Food increases!";
            huntingReward = false;
        } else if (huntingAccident) {
            eventCanvas.SetActive(true);
            titleMain.text = "Hunting Accident";
            bodyMain.text = "The dinos were ambushed by the humies. Dino lives were lost!";
            huntingAccident = false;
        } else if (miningReward) {
            eventCanvas.SetActive(true);
            titleMain.text = "Mining Reward";
            bodyMain.text = "The dinos found some rare ore. Income increases!";
            miningReward = false;
        } else if (miningAccident) {
            eventCanvas.SetActive(true);
            titleMain.text = "Mining Accident";
            bodyMain.text = "The mine has collapsed! Some of the dinos have perished. Dino lives were lost!";
            miningAccident = false;
        } else if (zombieEvent) {
            eventCanvas.SetActive(true);
            titleMain.text = "Zombie Apocalypse";
            bodyMain.text = "The orb is reacting with the rotten food causing the dinos to zombify. Resources decrease!";
            zombieEvent = false;
        } else if (rottenFoodEvent) {
            eventCanvas.SetActive(true);
            titleMain.text = "Rotten Food";
            bodyMain.text = "Some of your food supply has turned rotten. Food decreases!";
            rottenFoodEvent = false;
        } else if (merchantEvent) {
            eventCanvas.SetActive(true);
            titleMain.text = "Merchant Visit";
            bodyMain.text = "A merchant has come to visit. Income increases!";
            merchantEvent = false;
        } else if (meteorEvent) {
            eventCanvas.SetActive(true);
            titleMain.text = "Doomsday Meteorite";
            bodyMain.text = "A meteorite has fallen and has destroyed your entire village. Dinos wiped out!";
            meteorEvent = false;
        } else if (invasionEvent) {
            choiceCanvas.SetActive(true);
            titleChoice.text = "Invasion";
            bodyChoice.text = "The humies have invaded. What resource are you going to protect?";
            leftChoice.text = "Income";
            rightChoice.text = "Food";
        } else if (coupEvent) {
            eventCanvas.SetActive(true);
            titleMain.text = "Coup d'etat";
            bodyMain.text = "Some dinos have banded together and started a coup d'etat. Resources decrease!";
            coupEvent = false;
        } else if (mageEvent) {
            choiceCanvas.SetActive(true);
            titleChoice.text = "Mage Visit";
            bodyChoice.text = "A mage has come to visit the village. Are you willing to let them stay?";
            leftChoice.text = "No";
            rightChoice.text = "Yes";
        } else if (skeletonEvent) {
            eventCanvas.SetActive(true);
            titleMain.text = "Skeleton Uprising";
            bodyMain.text = "The mage has accidently summoned skeletons. Population decreases!";
            skeletonEvent = false;
        } else if (cultEvent) {
            eventCanvas.SetActive(true);
            titleMain.text = "Yellow Dinosaur Cult";
            bodyMain.text = "The yellow dinos feel sympathy for the humies, and have decided to free some of them. Food decreases!";
            cultEvent = false;
        } else if (godEvent) {
            eventCanvas.SetActive(true);
            titleMain.text = "Literal God Smite";
            bodyMain.text = "A god smites the village. Resources decrease!";
            godEvent = false;
        } else if (orbEvent) {
            choiceCanvas.SetActive(true);
            titleChoice.text = "Orb";
            bodyChoice.text = "Your scouts have found a magical orb. Would you like to keep it?";
            leftChoice.text = "No";
            rightChoice.text = "Yes";            
        } else if (weaponsEvent) {
            choiceCanvas.SetActive(true);
            titleChoice.text = "Weapons";
            bodyChoice.text = "Your scouts have found some weapons. Would you like to keep them?";
            leftChoice.text = "No";
            rightChoice.text = "Yes";            
        } else if (itemEvent) {
            eventCanvas.SetActive(true);
            titleMain.text = "Mysterious Item";
            bodyMain.text = "Your scouts have brought back a mysterious item.";            
        }
    }

    public void LeftOption() {
        if (invasionEvent) {
            invasionEvent = false;
        } else if (mageEvent) {
            mageEvent = false;
        } else if (orbEvent) {
            orbEvent = false;
        } else if (weaponsEvent) {
            weaponsEvent = false;
        } else if (itemEvent) {
            itemEvent = false;
        }

        eventCanvas.SetActive(false);
        choiceCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void RightOption() {
        if (invasionEvent) {
            invasionEvent = false;
        } else if (mageEvent) {
            mageAccepted = true;
            mageEvent = false;
        } else if (orbEvent) {
            orbReceived = true;
            orbEvent = false;
        } else if (weaponsEvent) {
            weaponsReceived = true;
            weaponsEvent = false;
        } else if (itemEvent) {
            itemReceived = true;
            itemEvent = false;
        }

        eventCanvas.SetActive(false);
        choiceCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void CloseOption() {
        eventCanvas.SetActive(false);
        choiceCanvas.SetActive(false);
        Time.timeScale = 1;
    }

}

