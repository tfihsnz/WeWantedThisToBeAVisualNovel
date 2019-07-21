using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosWalk : MonoBehaviour
{
    Vector2 Loc1;
    Vector2 Loc2;
    Vector2 Loc3;
    Vector2 Loc4;
    Vector2 Loc5;
    Vector2 Loc6;
    Vector2 Loc7;
    Vector2 Loc8;
    public int population;
    public GameObject prefab;
    public float spawn;
    public GameObject littleman;

    void Start()
    {
        population = 10;
        for (int i = 0; i < population; i++)
        {
            Loc1.x = 8;
            Loc1.y = 1;
            Loc2.x = 1;
            Loc2.y = 2;
            Loc3.x = 1;
            Loc3.y = -1;
            Loc4.x = 4;
            Loc4.y = 0;
            Loc5.x = -2;
            Loc5.y = -2;
            Loc6.x = -3;
            Loc6.y = 1;
            Loc7.x = -4;
            Loc7.y = 3;
            Loc8.x = -5;
            Loc8.y = 0;
            spawn = Random.Range(0, 8);
            if (spawn <= 1)
            {
                littleman = Instantiate(prefab, Loc1, Quaternion.identity);
            }
            else if (spawn <= 2){
                littleman = Instantiate(prefab, Loc2, Quaternion.identity);
            }
            else if (spawn <= 3){
                littleman = Instantiate(prefab, Loc3, Quaternion.identity);
            }
            else if (spawn <= 4){
                littleman = Instantiate(prefab, Loc4, Quaternion.identity);
            }
            else if (spawn <= 5){
                littleman = Instantiate(prefab, Loc5, Quaternion.identity);
            }
            else if (spawn <= 6){
                littleman = Instantiate(prefab, Loc6, Quaternion.identity);
            }
            else if (spawn <= 7){
                littleman = Instantiate(prefab, Loc7, Quaternion.identity);
            }
            else if (spawn <= 8){
                littleman = Instantiate(prefab, Loc8, Quaternion.identity);
            }

        }
        Destroy(littleman);
        Destroy(littleman);
        Destroy(littleman);
        Destroy(littleman);
        Destroy(littleman);
        Destroy(littleman);
    }
}
