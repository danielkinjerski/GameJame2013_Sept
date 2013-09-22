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
            print(Time.time);
            yield return null;
        }
        print("time Up");
        yield break;
    }

    void Update()
    {

    }

    #endregion

    #region Utilities

    #endregion


}
