using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public AudioSource ClickSound;
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        ClickSound.Play(); // 음향 재생
        GameManager.instance.GameExit();
    }
}
