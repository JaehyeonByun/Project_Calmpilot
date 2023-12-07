using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClapSound : MonoBehaviour
{
    public AudioSource clapSound;
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DoClapSound", 12f);
    }
    void DoClapSound()
    {
        clapSound.Play();
  
    }
}
