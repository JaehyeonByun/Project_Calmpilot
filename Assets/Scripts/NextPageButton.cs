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

<<<<<<< HEAD
<<<<<<< HEAD


=======
=======
>>>>>>> parent of 0dbfa40 (.)
    // Start is called before the first frame update
>>>>>>> parent of 0dbfa40 (.)
    public void OnButtonClick()
    {
        ClickSound.Play(); // 음향 재생
        Page.SetActive(false);
        NextPage.SetActive(true);
    }
}
