using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        MainMenu,
        LectureRoom,
        ConcertHall,
        Interview,
        GameEnd,
    }

    public GameState gameState;

    public TMP_Text timerText; // 유니티 UI Text 오브젝트에 연결할 Text 컴포넌트
    private float countdownTime = 120.0f;

    public void GameMenu()
    {
        SceneManager.LoadScene("MainMenu");
        gameState = GameState.MainMenu;
    }
    public void LectureRoom()
    {
        SceneManager.LoadScene("Room1");
        gameState = GameState.LectureRoom;
;
    }
    public void ConcertHall()
    {
        SceneManager.LoadScene("Room2");
        gameState = GameState.ConcertHall;
        ;
    }
    public void Interview()
    {
        SceneManager.LoadScene("Room3");
        gameState = GameState.Interview;
        ;
    }
    public void GameExit()
    {
        UnityEngine.Application.Quit();
        gameState = GameState.GameEnd;
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.MainMenu)
        {

        }
      
        else if (gameState == GameState.GameEnd)
        {

        }
    }
}
