using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public Animator QuestionAnimation;
    public AudioSource QuestionAudioSource;
    public GameObject EndAnswer;
    public GameObject Accept;


    public void OnButtonClick()
    {
        Accept.SetActive(false);
        QuestionAnimation.SetBool("Question", false);
        QuestionAudioSource.Play();
        Invoke("DoEndAnswer", 5f);
       
    }
   
    public void DoEndAnswer()
    {
        EndAnswer.SetActive(true);
    }
}
