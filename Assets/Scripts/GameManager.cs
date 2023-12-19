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
        Frequency,
        TapTap,
        Breathe,
        NoFeedback,
        GameEnd,
    }

    public GameState gameState;

    public TMP_Text timerText;
    private float countdownTime = 120.0f;

    public void GameMenu()
    {
        SceneManager.LoadScene("MainMenu");
        gameState = GameState.MainMenu;
    }
    public void Frequency()
    {
        SceneManager.LoadScene("Room1");
        gameState = GameState.Frequency;
;
    }
    public void TapTap()
    {
        SceneManager.LoadScene("Room2");
        gameState = GameState.TapTap;
        ;
    }
    public void Breathe()
    {
        SceneManager.LoadScene("Room3");
        gameState = GameState.Breathe;
        ;
    }
    public void NoFeedback()
    {
        SceneManager.LoadScene("Room4");
        gameState = GameState.NoFeedback;
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
