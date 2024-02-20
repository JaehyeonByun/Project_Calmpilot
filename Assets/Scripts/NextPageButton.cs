using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPageButton : MonoBehaviour
{
    public AudioSource ClickSound;
    public GameObject Page;
    public GameObject NextPage;
    public GameObject Hannounce;
    public GameObject PPTannounce;
    public GameObject Questannounce;

    public GameObject scripts;
    public GameObject ppt;

    // Start is called before the first frame update
    public void OnButtonClick()
    {
        ClickSound.Play(); // 음향 재생
        Page.SetActive(false);
        NextPage.SetActive(true);
        Hannounce.SetActive(true);
        PPTannounce.SetActive(true);
        Questannounce.SetActive(true);
        scripts.SetActive(true);
        ppt.SetActive(true);

    }
}
