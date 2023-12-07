using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoStage : MonoBehaviour
{
    public AudioSource ClickSound;
    public void GoButtonClick()
        {
        ClickSound.Play();
        GameManager.instance.LectureRoom();
    }
    }