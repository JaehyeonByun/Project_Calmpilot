using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bhaptics.SDK2;

public class SaveToCSV : MonoBehaviour
{
    public GameObject heart;
    public void OnButtonClick() { 
        heart.GetComponent<hyperateSocket>().SaveToCSV_PR();
    }
}
