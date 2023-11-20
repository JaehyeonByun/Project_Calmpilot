using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calling : MonoBehaviour

{
    public GameObject uiElement;
    public GameObject Call; 
    public AudioSource audioSource;
    public AudioSource voice;


    // 버튼 클릭 시 호출될 함수
    public void OnButtonClick()
    {
        audioSource.Play(); // 음향 재생
        Call.SetActive(true);
        uiElement.SetActive(false);
        Invoke("PlaySound", 2f);
        Invoke("Mainmenu", 23f);

    }

public void Mainmenu()
    {
        Call.SetActive(false);
    }
public void PlaySound()
{
    voice.Play();
}
}