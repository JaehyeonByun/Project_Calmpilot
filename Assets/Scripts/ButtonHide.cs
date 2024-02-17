using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHide : MonoBehaviour
{
    public GameObject hide1;
    public GameObject hide2;
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        hide1.SetActive(false);
        hide1.SetActive(false);
    }

    // Update is called once per frame
}
