/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLevelDetector : MonoBehaviour
{
    private Microphone _microphone;
    private float[] _spectrumData;

    private void Start()
    {
        // 마이크를 초기화합니다.
        _microphone = Microphone.Start(null, 44100, 1);
        _spectrumData = new float[256];
    }

    private void Update()
    {
        // 음성 스펙트럼 데이터를 가져옵니다.
        _microphone.GetSpectrumData(_spectrumData, 0, FFTWindow.BlackmanHarris);

        // 목소리 크기를 계산합니다.
        float voiceLevel = 0f;
        for (int i = 0; i < _spectrumData.Length; i++)
        {
            voiceLevel += _spectrumData[i];
        }

        // 목소리 크기가 작으면 UI에 "목소리를 키우세요" 메시지를 띄웁니다.
        if (voiceLevel < 0.5f)
        {
            // UI를 활성화합니다.
            ui.SetActive(true);
        }
        else
        {
            // UI를 비활성화합니다.
            ui.SetActive(false);
        }
    }
}*/