using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndPresentaition : MonoBehaviour
{
    public GameObject[] EndPT;

    public void OnButtonClick()
    {
        foreach (GameObject obj in EndPT)
        {
            Clap clapComponent = obj.GetComponent<Clap>();
            if (clapComponent != null)
            {
                clapComponent.DoClap();
            }
        }
        
    }
}
