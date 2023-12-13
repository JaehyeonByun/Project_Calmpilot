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
    
}

public class hyperateSocket : MonoBehaviour
{
	// Put your websocket Token ID here
    public string websocketToken2 = "iXiyxevGDyhWff3YnvEfpcCdKMJvArtSYyUkrXF6Siq1qhBrSkB9zsYVjGWhFPh3"; //You don't have one, get it here https://www.hyperate.io/api
    public string hyperateID2 = "C21C";
	// Textbox to display your heart rate in

    List<NumberInfo> numberInfoList = new List<NumberInfo>();
    Text textBox;
	// Websocket for connection with Hyperate
    WebSocket websocket;
    async void Start()
    {
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
                TimeStamp = DateTime.Now // 현재 시간 정보 저장
            };

            numberInfoList.Add(info);

            Debug.Log(numberInfoList[0].Value);

            // CSV 파일 생성 및 데이터 쓰기
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sw.WriteLine(string.Join(",", row1));
            }

            if (msg["event"].ToString() == "hr_update")
            {
                // Change textbox text into the newly received Heart Rate (integer like "86" which represents beats per minute)
                textBox.text = (string) msg["payload"]["hr"];
            }
        };

        // Send heartbeat message every 25seconds in order to not suspended the connection
        InvokeRepeating("SendHeartbeat", 1.0f, 25.0f);

        // waiting for messages
        await websocket.Connect();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            {
               SaveToCSV(); // CSV 파일로 저장하는 함수 호출
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
            await websocket.SendText("{\"topic\": \"hr:"+hyperateID2+"\", \"event\": \"phx_join\", \"payload\": {}, \"ref\": 0}");
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

    async void SaveToCSV() {
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
                sw.WriteLine("TimeStamp,Value");

                // 데이터 쓰기
                foreach (var info in numberInfoList)
                {
                    string line = $"{info.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss")},{info.Value}";
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

public class HyperateResponse
{
    public string Event { get; set; }
    public string Payload { get; set; }
    public string Ref { get; set; }
    public string Topic { get; set; }
}
