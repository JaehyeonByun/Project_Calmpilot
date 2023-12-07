using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clap : MonoBehaviour
{
    public Animator ClapAnimation;


    private void Start()
    {
        Invoke("DoClap", 12f);
    }

    public void DoClap()
    {
        ClapAnimation.SetBool("Clap", true);
      
        Invoke("StopClap", 6f);
    }
  
    public void StopClap()
    {
        ClapAnimation.SetBool("Clap", false);
    }
  
}
