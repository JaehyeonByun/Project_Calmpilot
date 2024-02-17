using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mic : MonoBehaviour
{
    public AudioSource mic; //마이크로 녹음된 소리를 재생할 오디오소스 컴포넌트

    void Start()
    {
        //컴퓨터에 등록된 마이크를 배열에 등록
        string[] myMic = Microphone.devices;
        for (int i = 0; i < myMic.Length; i++)
        {
            Debug.Log(Microphone.devices[i].ToString());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //오디오 소스 클립에 마이크값을 지정(배열 안에 숫자를 통해 마이크 선택)
            //100과 44100은 음량 관련 값
            mic.clip = Microphone.Start(Microphone.devices[0].ToString(), true, 100, 44100);
            //딜레이를 줄이기 위해 추가한 코드
            while (!(Microphone.GetPosition(null) > 0)) { }
            //마이크 녹음 재생
            mic.Play();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            mic.Stop();
        }
    }
}