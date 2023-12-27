using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoStage2 : MonoBehaviour
{
    public AudioSource ClickSound;
    public void GoButtonClick()
        {
        ClickSound.Play();
        GameManager.instance.Breathe();
        Debug.Log("Go To Stage" + DateTime.Now);
    }
    }