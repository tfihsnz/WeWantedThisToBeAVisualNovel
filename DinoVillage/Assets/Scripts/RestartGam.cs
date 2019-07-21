using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartGam : MonoBehaviour
{
    public GameObject EndCanvas;
    public AudioSource ClickSound;
    public Image YouDied;
    public Text TextYD;

    // Start is called before the first frame update
    void Start()
    {
        YouDied.GetComponent<CanvasRenderer>().SetAlpha(0.1f);
        TextYD.GetComponent<CanvasRenderer>().SetAlpha(0.1f);
        YouDied.CrossFadeAlpha(1f, 2f, false);
        TextYD.CrossFadeAlpha(1f, 1.5f, false);
    }

    public void RestartGame()
    {
        ClickSound = GetComponent<AudioSource>();
        ClickSound.Play(1);
        EndCanvas.SetActive(false);
        Application.LoadLevel(Application.loadedLevel);
    }

}
