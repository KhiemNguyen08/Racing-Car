using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs 
{
  public static int bestScore
    {
        set
        {
            if (PlayerPrefs.GetInt(COnst.BEST_SCORE_KEY, 0) < value)
            {
                PlayerPrefs.SetInt(COnst.BEST_SCORE_KEY, value);
            }
        }
        get => PlayerPrefs.GetInt(COnst.BEST_SCORE_KEY, 0);
    }
}
