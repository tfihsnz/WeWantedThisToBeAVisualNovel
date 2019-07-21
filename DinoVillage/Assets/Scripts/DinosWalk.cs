using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosWalk : MonoBehaviour
{
    public GameObject Dino;
    Vector2 Nextpos;
    public float NextPos;

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
    // Start is called before the first frame update
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
            //public vector2Int loc = (guy.Xaxis, guy.Yaxis) ;
            //Dino.transform.Translate(loc);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
