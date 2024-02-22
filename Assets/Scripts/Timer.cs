using Bhaptics.SDK2;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
public class Timer : MonoBehaviour
{
    public GameObject heart;

    public AudioSource Warning;

    public TMP_Text timeText;
    private float time;
    private void Awake()
    {
        time = 120f;
    }
    private void Update()
    {
        if (timeText == null)
            timeText = GameObject.Find("Timer").GetComponent<TMP_Text>();
        if (time > 0)
        {
            time -= Time.deltaTime;
            if(time > 30)
            {
                Warning.Play();
            }
        }
        else {
            heart.GetComponent<hyperateSocket>().SaveToCSV_Ready();
            GameManager.instance.Frequency();
        }
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);


        timeText.text = time.ToString();
        timeText.text = string.Format("{0}:{1:00}", minutes, seconds);

    }
}
