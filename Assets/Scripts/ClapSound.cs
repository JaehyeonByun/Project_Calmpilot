using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClapSound : MonoBehaviour
{
    public AudioSource clapSound;
    public GameObject StartButton;
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DoClapSound", 12f);

    }
    void DoClapSound()
    {
        clapSound.Play();
        Invoke("StartButtonOn", 1.5f);
    }

    public void StartButtonOn()
    {
        StartButton.SetActive(true);
    }
}
