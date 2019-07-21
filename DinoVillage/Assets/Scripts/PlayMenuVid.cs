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
    public GameObject CreditUI;
    public AudioSource ClickSound;

    // Start is called before the first frame update
    void Start()
    {
        CreditUI.SetActive(false);
        MainUiCan.SetActive(false);
        Time.timeScale = 0;
        gameObject.GetComponent<RawImage>().texture = movie;
        movie.Play();
        movie.loop = true;
    }

    public void PlayGame()
    {
        ClickSound = GetComponent<AudioSource>();
        ClickSound.Play(1);
        Time.timeScale = 1;
        MenuCanvas.SetActive(false);
        MainUiCan.SetActive(true);

    }  

    public void QuitGame()
    {
        ClickSound = GetComponent<AudioSource>();
        ClickSound.Play(1);
        Application.Quit();
    }

    public void Credits()
    {
        ClickSound = GetComponent<AudioSource>();
        ClickSound.Play(1);
        CreditUI.SetActive(true);
    }

    public void CreditsBack()
    {
        ClickSound = GetComponent<AudioSource>();
        ClickSound.Play(1);
        CreditUI.SetActive(false);
    }
}
