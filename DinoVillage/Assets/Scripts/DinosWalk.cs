using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosWalk : MonoBehaviour
{
    Vector2 nextLoc;
    public int population;
    public GameObject prefab;


    public class Locations
    {
        public int Xaxis;
        public int Yaxis;

        public Locations(int newXaxis, int newYaxis)
        {
            Xaxis = newXaxis;
            Yaxis = newYaxis;
        }
    }

    void Start()
    {
        List<Locations> locations = new List<Locations>();

        locations.Add(new Locations(8, 1));
        locations.Add(new Locations(1, 2));
        locations.Add(new Locations(1, -1));
        locations.Add(new Locations(4, 0));
        locations.Add(new Locations(-2, -2));
        locations.Add(new Locations(-3, 1));
        locations.Add(new Locations(-4, 3));
        locations.Add(new Locations(-5, 0));

        foreach(Locations guy in locations)
        {
            nextLoc.x = guy.Xaxis;
            nextLoc.y = guy.Yaxis;
        }

        population = 10;
        for (int i = 0; i < population; i++)
        {
            
            Instantiate(prefab, nextLoc, Quaternion.identity);

        }
    }
}
