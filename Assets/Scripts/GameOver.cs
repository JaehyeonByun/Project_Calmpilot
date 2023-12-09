using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TMP_Text timeText;
    private float time;

    public GameObject GameOverUI;
    public AudioSource GameOverSound;
    public GameObject GameUI;

    void Awake()
    {
        time = 300f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeText == null)
            timeText = GameObject.Find("Timer").GetComponent<TMP_Text>();
        if (time > 0)
            time -= Time.deltaTime;
        else
        {
            GameOverSound.Play();
            GameOverUI.SetActive(true);
            GameUI.SetActive(false);
        }

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);


        timeText.text = time.ToString();
        timeText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
}
