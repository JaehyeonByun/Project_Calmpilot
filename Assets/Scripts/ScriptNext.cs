using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptNext : MonoBehaviour
{
    public AudioSource ClickSound;
    public GameObject Script;
    public GameObject PPT;
    public GameObject NextScript;
    public GameObject NextPPT;
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        ClickSound.Play(); // 음향 재생
        Script.SetActive(false);
        PPT.SetActive(false);
        NextScript.SetActive(true);
        NextPPT.SetActive(true);

    }
}
