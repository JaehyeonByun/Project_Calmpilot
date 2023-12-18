using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnswer : MonoBehaviour
{
    public GameObject Answer;
    public GameObject Next;

    public void OnButtonClick()
    {
        Answer.SetActive(false);
        Next.SetActive(true);
    } }
