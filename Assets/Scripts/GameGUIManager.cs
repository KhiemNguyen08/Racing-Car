using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject homeGUI;
    public GameObject gameGUI;
    public Text timeCountingText;
    public Text scoreCountingText;
    public Dialog gameOverDialog;
    public Dialog pauseDialog;
    public override void Awake()
    {
        MakeSingleton(false);
    }
    public void ShowGameGUI(bool isshow)
    {
        if (gameGUI)
            gameGUI.SetActive(isshow);
        if (homeGUI)
            homeGUI.SetActive(!isshow);
    }
    public void UpdateTimeCounting(float time)
    {
        if (timeCountingText)
            timeCountingText.gameObject.SetActive(true);
            timeCountingText.text = time.ToString();
        if (time <= 0)
        {
            timeCountingText.gameObject.SetActive(false);
        }
    }
    public void UpdateScoreCouting(int score)
    {
        if (scoreCountingText)
            scoreCountingText.text ="Score : "+ score.ToString();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        if (pauseDialog)
            pauseDialog.Show(true);
    }
}
