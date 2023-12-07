using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GotoReady : MonoBehaviour
{
    public GameObject uiElement;
    public GameObject Call;
    public GameObject Menu;
    public AudioSource Ring;
    public AudioSource voice;
    public void OnButtonClick()
    {
        Ring.Play(); // 음향 재생
        Call.SetActive(true);
        uiElement.SetActive(false);
        Invoke("PlaySound", 2f);
        Invoke("Mainmenu", 23f);

    }

    public void Mainmenu()
    {
        Call.SetActive(false);
        Menu.SetActive(true);

    }
    public void PlaySound()
    {
        voice.Play();
    }
}
