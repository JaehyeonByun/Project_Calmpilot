using Bhaptics.SDK2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveToCSV : MonoBehaviour
{
    public GameObject obj;

    public void onButtonClick()
    {
        obj.GetComponent<hyperateSocket>().SaveToCSV();
    }
}
