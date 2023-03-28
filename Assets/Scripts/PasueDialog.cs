using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasueDialog : Dialog
{
   public void UnPauseGame()
    {
        Time.timeScale = 1;
        Show(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
