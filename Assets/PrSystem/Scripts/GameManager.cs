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
        GameStart1,
        GamePaused,
        GameEnd
    }

    public GameState gameState;

    public void GameStart1()
    {
        SceneManager.LoadScene("Conference1");
        gameState = GameState.GameStart1;
    }
    public void GameMenu()
    {
        SceneManager.LoadScene("MainMenu");
        gameState = GameState.MainMenu;
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
        else if (gameState == GameState.GameStart1)
        {

        }
        else if (gameState == GameState.GameEnd)
        {

        }
    }
}
