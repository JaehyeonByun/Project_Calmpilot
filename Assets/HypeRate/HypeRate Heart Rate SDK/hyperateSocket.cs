using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;
using NativeWebSocket;

using System.IO;
using System.Text;


public class NumberInfo
{
    public DateTime TimeStamp { get; set; }
    public int Value { get; set; }
    public bool HapticFeedbackTriggered { get; set; }

}

public class ButtonInfo
{
    public DateTime TimeStamp { get; set; }
    public string ButtonIdentifier { get; set; }

}

namespace Bhaptics.SDK2
{
    public class hyperateSocket : MonoBehaviour
    {
        // Put your websocket Token ID here
        public string websocketToken2 = "iXiyxevGDyhWff3YnvEfpcCdKMJvArtSYyUkrXF6Siq1qhBrSkB9zsYVjGWhFPh3"; //You don't have one, get it here https://www.hyperate.io/api
        public string hyperateID7 = "03ae20";

        // Textbox to display your heart rate in
        List<NumberInfo> numberInfoList = new List<NumberInfo>();
        public List<ButtonInfo> numberButtonList = new List<ButtonInfo>();
        Text textBox;
        // Websocket for connection with Hyperate
        WebSocket websocket;

        // Variables for BHaptics Feedback
        private float heartRateCheckInterval = 5f; // interval to check heart rate
        private bool isHeartRateHigh = false; // flag to track if heart rate is high
        private float timeSinceHighHeartRate = 0f; // time since heart rate first went high
        private DateTime lastFeedbackTime = DateTime.MinValue;


        async void Start()
        {
            numberButtonList = new List<ButtonInfo>();
            textBox = GetComponent<Text>();

            websocket = new WebSocket("wss://app.hyperate.io/socket/websocket?token=" + websocketToken2);
            Debug.Log("Connect!");

            websocket.OnOpen += () =>
            {
                Debug.Log("Connection open!");
                SendWebSocketMessage();
            };

            websocket.OnError += (e) =>
            {
                Debug.Log("Error! " + e);
            };

            websocket.OnClose += (e) =>
            {
                Debug.Log("Connection closed!");
            };

            string filePath = "example.csv"; // CSV 파일 경로 및 이름


            websocket.OnMessage += (bytes) =>
            {
                // getting the message as a string
                var message = System.Text.Encoding.UTF8.GetString(bytes);
                var msg = JObject.Parse(message);

                string[] row1 = { "Charlie", (string)msg["payload"]["hr"], "매니저" };
               

                NumberInfo info = new NumberInfo
                {
                    Value = (int)msg["payload"]["hr"], // 임의의 숫자 값 생성 (1부터 100 사이)
                    TimeStamp = DateTime.Now, // 현재 시간 정보 저장
                    HapticFeedbackTriggered = false // Haptic feedback 여부
                };

                // CSV 파일 생성 및 데이터 쓰기
                using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    sw.WriteLine(string.Join(",", row1));
                }

                if (msg["event"].ToString() == "hr_update")
                {
                    // Change textbox text into the newly received Heart Rate (integer like "86" which represents beats per minute)
                    textBox.text = (string)msg["payload"]["hr"];
                }
                if ((DateTime.Now - lastFeedbackTime).TotalSeconds >= 9)
                {
                    if (info.Value >= 115)
                    {
                        Debug.Log(info.Value);
                        BhapticsLibrary.Play("breathing_guide_10s"); // second haptic feedback
                        isHeartRateHigh = false; // reset the state
                        lastFeedbackTime = DateTime.Now;
                        info.HapticFeedbackTriggered = true;
                    }
                }

                numberInfoList.Add(info);
                // Debug.Log("Write HeartRate" + info.Value);

            };

            // Send heartbeat message every 25seconds in order to not suspended the connection
            InvokeRepeating("SendHeartbeat", 1.0f, 25.0f);

            // Play CheckHeartRate
            // InvokeRepeating("CheckHeartRate", 0f, heartRateCheckInterval);


            // waiting for messages
            await websocket.Connect();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                SaveToCSV(); // CSV 파일로 저장하는 함수 호출
                // SaveToCSVHaptic();
            }
#if !UNITY_WEBGL || UNITY_EDITOR
            websocket.DispatchMessageQueue();
#endif
        }

        async void SendWebSocketMessage()
        {
            if (websocket.State == WebSocketState.Open)
            {
                // Log into the "internal-testing" channel
                await websocket.SendText("{\"topic\": \"hr:" + hyperateID7 + "\", \"event\": \"phx_join\", \"payload\": {}, \"ref\": 0}");
            }
        }
        async void SendHeartbeat()
        {
            if (websocket.State == WebSocketState.Open)
            {
                // Send heartbeat message in order to not be suspended from the connection
                await websocket.SendText("{\"topic\": \"phoenix\",\"event\": \"heartbeat\",\"payload\": {},\"ref\": 0}");

            }
        }

        // Public method to add ButtonInfo
        public void AddToButtonList(ButtonInfo buttonInfo)
        {
            // If necessary, add thread safety here
            numberButtonList.Add(buttonInfo);
        }

        public async void SaveToCSV()
        {
            Debug.Log("SAVETOCSV");
            if (numberInfoList.Count == 0)
            {
                Console.WriteLine("저장된 데이터가 없습니다.");
                return;
            }

            string csvFilePath = "NumberInfo.csv";

            try
            {
                using (StreamWriter sw = new StreamWriter(csvFilePath, false, Encoding.UTF8))
                {
                    // CSV 파일 헤더 작성
                    sw.WriteLine("TimeStamp,Value,HapticFeedback");

                    // 데이터 쓰기
                    foreach (var info in numberInfoList)
                    {
                        string line = $"{info.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss")},{info.Value},{info.HapticFeedbackTriggered}";
                        sw.WriteLine(line);
                    }
                }

                Console.WriteLine($"CSV 파일이 성공적으로 생성되었습니다. 경로: {Path.GetFullPath(csvFilePath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CSV 파일 생성 중 오류 발생: {ex.Message}");
            }
        }

        public async void SaveToCSV_Ready()
        {
            Debug.Log("SAVETOCSV");
            if (numberInfoList.Count == 0)
            {
                Console.WriteLine("저장된 데이터가 없습니다.");
                return;
            }

            string csvFilePath = "Ready Heartrate.csv";

            try
            {
                using (StreamWriter sw = new StreamWriter(csvFilePath, false, Encoding.UTF8))
                {
                    // CSV 파일 헤더 작성
                    sw.WriteLine("TimeStamp,Value,HapticFeedback");

                    // 데이터 쓰기
                    foreach (var info in numberInfoList)
                    {
                        string line = $"{info.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss")},{info.Value},{info.HapticFeedbackTriggered}";
                        sw.WriteLine(line);
                    }
                }

                Console.WriteLine($"CSV 파일이 성공적으로 생성되었습니다. 경로: {Path.GetFullPath(csvFilePath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CSV 파일 생성 중 오류 발생: {ex.Message}");
            }
        }

        public async void SaveToCSV_PR()
        {
            Debug.Log("SAVETOCSV");
            if (numberInfoList.Count == 0)
            {
                Console.WriteLine("저장된 데이터가 없습니다.");
                return;
            }

            string csvFilePath = "Public Speaking Heartrate.csv";

            try
            {
                using (StreamWriter sw = new StreamWriter(csvFilePath, false, Encoding.UTF8))
                {
                    // CSV 파일 헤더 작성
                    sw.WriteLine("TimeStamp,Value,HapticFeedback");

                    // 데이터 쓰기
                    foreach (var info in numberInfoList)
                    {
                        string line = $"{info.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss")},{info.Value},{info.HapticFeedbackTriggered}";
                        sw.WriteLine(line);
                    }
                }

                Console.WriteLine($"CSV 파일이 성공적으로 생성되었습니다. 경로: {Path.GetFullPath(csvFilePath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CSV 파일 생성 중 오류 발생: {ex.Message}");
            }
        }


        async void SaveToCSVHaptic()
        {
            Debug.Log("SAVETOCSVHaptic");
            if (numberButtonList.Count == 0)
            {
                Console.WriteLine("저장된 데이터가 없습니다.");
                return;
            }

            string csvFilePath = "ButtonInfo.csv";

            try
            {
                using (StreamWriter sw = new StreamWriter(csvFilePath, false, Encoding.UTF8))
                {
                    // CSV 파일 헤더 작성
                    sw.WriteLine("TimeStamp,ButtonIdentifier");

                    // 데이터 쓰기
                    foreach (var info in numberButtonList)
                    {
                        string line = $"{info.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss")},{info.ButtonIdentifier}";
                        sw.WriteLine(line);
                    }
                }

                Console.WriteLine($"CSV 파일이 성공적으로 생성되었습니다. 경로: {Path.GetFullPath(csvFilePath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CSV 파일 생성 중 오류 발생: {ex.Message}");
            }
        }

        private async void OnApplicationQuit()
        {
            await websocket.Close();
        }

    }
}


public class HyperateResponse
{
    public string Event { get; set; }
    public string Payload { get; set; }
    public string Ref { get; set; }
    public string Topic { get; set; }
}
