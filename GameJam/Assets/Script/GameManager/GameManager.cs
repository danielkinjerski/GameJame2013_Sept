using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#region Enums
public enum GameState
{
    OpeningWindow = 1,
    PlayGame = 2,
    GameOver = 3,
    Pause = 4
}
public  enum CurrentPlayMode
{
    Black = 1,
    White = 2,
    Grey = 3
}
#endregion


public class GameManager : MonoBehaviour
{
    public delegate void GameOver();
    public delegate void LabelUpdate(string text);
    public delegate void SummaryUpdate(string vcell, string wcell);
    public event LabelUpdate OnTimerIncrement;
    public event LabelUpdate OnWhiteBloodCountChange;
    public event LabelUpdate OnVirusCellCountChange;
    public event GameOver OnGameOver;
    public event SummaryUpdate OnSummaryUpdate;

    public string levels;

    #region Variables

    float levelTimer = 0;
    public float maxTime = 60;
    public int whiteBloodCount = 500;
    public int virusCount = 1;

    #endregion

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    #region UI Events

    void OnPlay()
    {
        Application.LoadLevel(levels);
    }

    void StartGame()
    {
        Debug.Log("start");
        StartCoroutine(GameTimer());
    }

    IEnumerator GameTimer()
    {
        levelTimer = Time.time;
        while (Time.time < levelTimer + maxTime)
        {
            if (OnTimerIncrement != null)
            {
                float timeLeft = maxTime - Time.time + levelTimer;
                float secs = timeLeft % 60;
                float mins = timeLeft / 60;
                OnTimerIncrement(string.Format("{0:00}:{1:00}", (int)mins, secs));
            }
            yield return null;
        }
        levelTimer = 0;

        if (OnGameOver != null)
        {
            OnGameOver();
        }       

        
        yield break;
    }

    void Update()
    {
        if (whiteBloodCount <= 200)
        {
            levelTimer = 0;

            if (OnGameOver != null)
            {
                OnGameOver();
            }       
        }
    }

    public void CellDie()
    {
        whiteBloodCount -= 20;
        if (OnWhiteBloodCountChange != null)
        {
            OnWhiteBloodCountChange(whiteBloodCount.ToString());
        }

        virusCount += 4;
        if (OnVirusCellCountChange != null)
        {
            OnVirusCellCountChange(virusCount.ToString());
        }
    }

    #endregion



}
