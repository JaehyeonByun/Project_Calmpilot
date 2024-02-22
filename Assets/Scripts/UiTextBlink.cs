using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiTextBlink : MonoBehaviour
{
    public Text text;
    public float blinkDuration = 3f;
    public float blinkInterval = 1f;
    public float fadeDuration = 1f; // 페이드 지속 시간

    void Start()
    {
        text.text = "<color=#FF0000>녹화</color> 진행중";
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            // 페이드 아웃
            for (float t = 1.0f; t >= 0.0f; t -= Time.deltaTime / fadeDuration)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, t);
                yield return null;
            }

            // 텍스트 비활성화
            text.enabled = false;

            // 간격 유지
            yield return new WaitForSeconds(blinkInterval);

            // 텍스트 활성화
            text.enabled = true;

            // 페이드 인
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / fadeDuration)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, t);
                yield return null;
            }
        }
    }
}
