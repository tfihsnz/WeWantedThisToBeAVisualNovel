using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenuVid : MonoBehaviour
{

    public MovieTexture movie;

    // Start is called before the first frame update
    void Start()
    {
        //((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
        //((MovieTexture)GetComponent<Renderer>().material.mainTexture).loop();
        gameObject.GetComponent<RawImage>().texture = movie;
        movie.Play();
        movie.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
