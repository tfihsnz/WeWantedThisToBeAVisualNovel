using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayMenuVid : MonoBehaviour
{
    public MovieTexture movie;
    public GameObject MenuCanvas;
    public GameObject MainUiCan;

    // Start is called before the first frame update
    void Start()
    {
        MainUiCan.SetActive(false);
        Time.timeScale = 0;
        gameObject.GetComponent<RawImage>().texture = movie;
        movie.Play();
        movie.loop = true;
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        MenuCanvas.SetActive(false);
        MainUiCan.SetActive(true);

    }  

    public void QuitGame()
    {
        Application.Quit();
    }
}
