using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPageButton : MonoBehaviour
{
    public AudioSource ClickSound;
    public GameObject Page;
    public GameObject NextPage;

    public GameObject Announce1;
    public GameObject Anoounce2;
    public GameObject Anoounce3;
    public GameObject PPT;
    public GameObject Script;
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        ClickSound.Play(); // 음향 재생
        Page.SetActive(false);
        NextPage.SetActive(true);
        Announce1.SetActive(true);
        Anoounce2.SetActive(true);
        Anoounce3.SetActive(true);
        PPT.SetActive(true);
        Script.SetActive(true);

    }
}
