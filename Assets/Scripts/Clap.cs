using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clap : MonoBehaviour
{
    public Animator ClapAnimation;
    public AudioSource clapSound;


    private void Start()
    {
        Invoke("DoClap", 5f);
    }

    void DoClap()
    {
        ClapAnimation.SetBool("Clap", true);
        clapSound.Play();
        Invoke("StopClap", 4f);
    }
    void StopClap()
    {
        ClapAnimation.SetBool("Clap", true);
    }
}
