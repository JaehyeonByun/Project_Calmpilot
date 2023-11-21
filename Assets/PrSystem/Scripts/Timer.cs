using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
public class Timer : MonoBehaviour
{

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
            time -= Time.deltaTime;
        else
            GameManager.instance.GameStart1();
        timeText.text = time.ToString();
        timeText.text = string.Format("{0:N0}", time);

    }
}
