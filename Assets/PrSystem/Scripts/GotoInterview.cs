using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoInterview : MonoBehaviour
{
    public AudioSource ClickSound;
    public void GoButtonClick()
    {
        ClickSound.Play();
        GameManager.instance.Interview();
    }
}
