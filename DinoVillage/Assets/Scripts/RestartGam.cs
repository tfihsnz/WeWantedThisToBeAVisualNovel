using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartGam : MonoBehaviour
{
    public MovieTexture movie;
    public GameObject EndCanvas;
    public AudioSource ClickSound;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<RawImage>().texture = movie;
        movie.Play();
        //movie.loop = true;
    }

    public void RestartGame()
    {
        ClickSound = GetComponent<AudioSource>();
        ClickSound.Play(1);
        EndCanvas.SetActive(false);
        Application.LoadLevel(Application.loadedLevel);
    }

}
