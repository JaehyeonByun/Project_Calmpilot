using Bhaptics.SDK2;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;




public class Question : MonoBehaviour
{
    public Animator QuestionAnimation;
    public AudioSource QuestionAudioSource;
    public GameObject Accept;
    public hyperateSocket numberHapticList;


    public void OnButtonClick()
    {
        Invoke("DoQuestion", 2f);
        /*ButtonInfo info = new ButtonInfo
        {
            TimeStamp = DateTime.Now, // 현재 시간 정보 저장
            ButtonTriggered = true // Haptic feedback 여부
        };
        numberHapticList.Add(info);*/
    }
    public void DoQuestion()
    {
        QuestionAnimation.SetBool("Question", true);
        QuestionAudioSource.Play();
        Invoke("DoAccept", 3f);
    }
    public void DoAccept()
    {
        Accept.SetActive(true);
    }
}

