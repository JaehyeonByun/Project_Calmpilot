using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earthquake : MonoBehaviour
{
    public float shakeDuration = 2f; // 지진이 지속되는 시간
    public float shakeMagnitude = 0.1f; // 지진의 강도
    public float waitTime = 0.05f; // 진동 간의 대기 시간

    private Vector3 originalPosition;
    private bool isShaking = false;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        // 지진이 시작되면
        if (Input.GetKeyDown(KeyCode.Space)) // Space 키를 눌러 지진을 시작합니다. 원하는 다른 키로 변경 가능합니다.
        {
            StartCoroutine(StartShake());
        }

        // 지진이 끝나면 원래 위치로 돌아가게 합니다.
        if (!isShaking)
        {
            transform.position = originalPosition;
        }
    }

    private IEnumerator StartShake()
    {
        isShaking = true;

        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            float z = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.position = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z + z);

            elapsed += Time.deltaTime;

            yield return new WaitForSeconds(waitTime); // 진동 간의 대기 시간을 추가합니다.
        }

        isShaking = false;
    }
}