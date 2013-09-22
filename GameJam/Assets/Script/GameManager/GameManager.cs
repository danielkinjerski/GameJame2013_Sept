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
    public delegate void LabelUpdate(string text);
    public event LabelUpdate OnTimerIncrement;
    public event LabelUpdate OnWhiteBloodCountChange;
    public event LabelUpdate OnVirusCellCountChange;

    public string levels;

    #region Variables

    float levelTimer = 0, maxTime;
    int whiteBloodCount = 500;
    int virusCount = 1;

    #endregion

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    #region UI Events

    void OnPlay()
    {
        Debug.Log("start");
        Application.LoadLevel(levels);
    }

    void StartGame()
    {
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
        print("time Up");
        levelTimer = 0;
        yield break;
    }

    void CellDie()
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

    #region Utilities

    #endregion


}
