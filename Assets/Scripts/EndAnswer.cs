using System;
using System.Collections;
using System.Collections.Generic;
using Bhaptics.SDK2;
using UnityEngine;

public class EndAnswer : MonoBehaviour
{
    public GameObject Answer;
    public GameObject Next;
    public hyperateSocket numberHapticList;

    public void OnButtonClick()
    {
        Answer.SetActive(false);
        Next.SetActive(true);
        Debug.Log("End Answer" + DateTime.Now);
    }
}
