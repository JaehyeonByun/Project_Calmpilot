using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyPresentation : MonoBehaviour
{
    public GameObject PPT;
    public GameObject SC;
    public GameObject intro;
    public GameObject butt;
  
  
    public void OnButtonClick()
    {
        PPT.SetActive(true);
        SC.SetActive(true);
        intro.SetActive(true);
        butt.SetActive(false);
    }
}
