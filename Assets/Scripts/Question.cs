using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Question : MonoBehaviour
{
    public Animator QuestionAnimation;
    public AudioSource QuestionAudioSource;
    public GameObject Accept;


    public void OnButtonClick()
    {
        Invoke("DoQuestion", 5f);
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

