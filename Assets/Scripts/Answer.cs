using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public Animator QuestionAnimation;
    public AudioSource QuestionAudioSource;
    public AudioSource NoAns;
    public GameObject EndAnswer;
    public GameObject Accept;
    public GameObject Next;

    private void Start()
    {
        Invoke("NoAnswer", 5f);
    }
    public void OnButtonClick()
    {
        Accept.SetActive(false);
        Next.SetActive(false);
        QuestionAnimation.SetBool("Question", false);
        QuestionAudioSource.Play();
        Invoke("DoEndAnswer", 8f);
       
    }
   
    public void DoEndAnswer()
    {
        EndAnswer.SetActive(true);
    }

    void NoAnswer()
    {
        Accept.SetActive(false);
        QuestionAnimation.SetBool("Question", false);
    }
}
