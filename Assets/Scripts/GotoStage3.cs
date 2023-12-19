using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoStage3 : MonoBehaviour
{
    public AudioSource ClickSound;
    public void GoButtonClick()
        {
        ClickSound.Play();
        GameManager.instance.NoFeedback();
    }
    }