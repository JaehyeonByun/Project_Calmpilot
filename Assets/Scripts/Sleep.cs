using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    public Animator ClapAnimation;
    public AudioSource SnooringSound;


    private void Start()
    {
        Invoke("DoSleep", 20f);
    }

    void DoSleep()
    {
        ClapAnimation.SetBool("Sleep", true);
        SnooringSound.Play();
    }

    void StopSleep()
    {
        ClapAnimation.SetBool("Sleep", false);
    }

}
