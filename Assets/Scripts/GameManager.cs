using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float minSpawnTime;
    public float maxSpawnTime;
    public GameObject[] obstaclePbs;
    public GameObject player;
    public BGLoop bg;
    public bool isGameover;
    public bool isGameplaying;
    int m_score;

    public int Score { get => m_score; set => m_score = value; }

    // Start is called before the first frame update
    public override void Awake()
    {
        MakeSingleton(false);
    }
    public override void Start()
    {
        base.Start();
        // StartCoroutine(SpawnObstacle());
        GameGUIManager.Ins.ShowGameGUI(false);
        GameGUIManager.Ins.UpdateScoreCouting(Score);
    }
    public void PlayGame()
    {
        GameGUIManager.Ins.homeGUI.SetActive(false);
        StartCoroutine(CoutingDown());
    }
    IEnumerator CoutingDown()
    {
        float time = 3f;
        GameGUIManager.Ins.UpdateTimeCounting(time);
        while (time > 0)
        {
            yield return new WaitForSeconds(1f);
            time--;
            GameGUIManager.Ins.UpdateTimeCounting(time);
            AudioController.Ins.PlaySound(AudioController.Ins.timeBeep);

        }
       // AudioController.Ins.PlaySound(AudioController.Ins.timeBeep);
        isGameplaying = true;
        if (player)
            player.SetActive(true);
        if (bg)
            bg.isStart=true;
        StartCoroutine(SpawnObstacle());
        GameGUIManager.Ins.ShowGameGUI(true);
        AudioController.Ins.PlayBackgroundMusic();
    }
    IEnumerator SpawnObstacle()
    {
        while (!isGameover)
        {
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime );
            if (obstaclePbs!= null && obstaclePbs.Length>0)
            {
                int ObsIdx = Random.Range(0, obstaclePbs.Length);
                GameObject obstacle = obstaclePbs[ObsIdx];
                if (obstacle)
                {
                    Vector3 obsPos = new Vector3(Random.Range(-1.4f, 1.4f), 8f, 0f);
                    Instantiate(obstacle, obsPos, Quaternion.identity);
                }
            }
        }
        
    }
    public void Gameover()
    {
        isGameover = true;
        isGameplaying = false;
        Prefs.bestScore = m_score;
        GameGUIManager.Ins.gameOverDialog.Show(true);
        AudioController.Ins.StopPlayMusic();
        AudioController.Ins.PlaySound(AudioController.Ins.explosion);
    }
}
