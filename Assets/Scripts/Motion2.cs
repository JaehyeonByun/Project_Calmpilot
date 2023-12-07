using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion2 : MonoBehaviour
{
    public Animator ClapAnimation;
    public AudioSource clapSound;

    private void Start()
    {
        Invoke("DoClap", 3.75f);
        
    }

    void DoClap()
    {
        ClapAnimation.SetBool("Clap", true);
        clapSound.Play();
        Invoke("StopClap", 2.5f);
    }
    void StopClap()
    {
        ClapAnimation.SetBool("Clap", true);
    }
}