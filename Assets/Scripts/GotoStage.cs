using System;
using System.Collections;
using System.Collections.Generic;
using Bhaptics.SDK2;
using UnityEngine;

public class GotoStage : MonoBehaviour
{
    public AudioSource ClickSound;
    public hyperateSocket numberButtonList;
    public void GoButtonClick()
        {
        ClickSound.Play();
        GameManager.instance.Frequency();
        ButtonInfo info = new ButtonInfo
        {
            TimeStamp = DateTime.Now, // ���� �ð� ���� ����
            ButtonIdentifier = "GoToStage" // Haptic feedback ����
        };
        numberButtonList.AddToButtonList(info);
    }


}