using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoHall : MonoBehaviour
{
    public AudioSource ClickSound;
    public void GoButtonClick()
    {
        ClickSound.Play();
        GameManager.instance.ConcertHall();
    }
}
