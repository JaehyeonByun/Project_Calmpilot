using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chairman : MonoBehaviour
{
    public AudioSource chairmanSound;
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DoChairmanSound", 2f);
    }
    void DoChairmanSound()
    {
        chairmanSound.Play();

    }
}
