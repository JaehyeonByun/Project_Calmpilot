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
    public hyperateSocket numberButtonList;


    public void OnButtonClick()
    {
        Invoke("DoQuestion", 2f);

    }
    public void DoQuestion()
    {
        QuestionAnimation.SetBool("Question", true);
        QuestionAudioSource.Play();
        Debug.Log("Question Info Write" + DateTime.Now);
        Invoke("DoAccept", 3f);
    }
    public void DoAccept()
    {
        Accept.SetActive(true);
    }
}

