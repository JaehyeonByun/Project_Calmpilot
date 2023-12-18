using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPresentation : MonoBehaviour
{
    public GameObject EndButton;
    public GameObject Timer;
    public AudioSource clapSound;
    public GameObject GameEnd;

    // Start is called before the first frame update
    public void OnButtonClick()
    {
        foreach (Clap clap in FindObjectsOfType<Clap>())
        {
            clap.DoClap();
        }
        clapSound.Play();
        EndButton.SetActive(false);
        Timer.SetActive(false);
        Invoke("PresentationEnd", 8f);

    }
    public void PresentationEnd()
    {
        GameEnd.SetActive(true);
    }
}
