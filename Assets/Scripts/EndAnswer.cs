using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnswer : MonoBehaviour
{
    public GameObject Answer;
    public void OnButtonClick()
    {
        Answer.SetActive(false);
    } }
