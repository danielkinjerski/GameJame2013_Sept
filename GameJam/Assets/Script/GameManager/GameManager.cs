using UnityEngine;
using System.Collections;

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
    public event LabelUpdate onTimerIncrement;
    public event LabelUpdate onWhiteBloodChange;
    public event LabelUpdate onVirusCellCountChange;

    #region Variables

    public float levelTimer = 0, maxTime;

    #endregion

    

    #region UI Events

    void PlayHit()
    {
        Debug.Log("Play");
        StartCoroutine(GameTimer());
    }

    IEnumerator GameTimer()
    {
        levelTimer = Time.time;
        while (Time.time < levelTimer + maxTime)
        {
            if (onTimerIncrement != null)
            {
                float timeLeft = maxTime - Time.time + levelTimer;
                float secs = timeLeft % 60;
                float mins = timeLeft / 60;
                onTimerIncrement(string.Format("{0:00}:{1:00}", (int)mins, secs));
            }
            yield return null;
        }
        print("time Up");
        levelTimer = 0;
        yield break;
    }

    void Update()
    {

    }

    #endregion

    #region Utilities

    #endregion


}
