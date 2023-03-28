using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverDialog : Dialog
{
    public Text scoreText;
    public Text bestscoreText;
    private void Start()
    {
        if (scoreText)
            scoreText.text = GameManager.Ins.Score.ToString();
        if (bestscoreText)
            bestscoreText.text = Prefs.bestScore.ToString();
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
