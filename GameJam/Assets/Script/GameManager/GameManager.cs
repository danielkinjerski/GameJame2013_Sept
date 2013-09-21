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

    public GameObject OpeningWindow, GameOverWindow, SelectionWindow, TutorialWindow,
                    BlackWorld, WhiteWorld,
                    BlackCam, WhiteCam, MainCam,
                    Facebook, fbbutton, fbsuccess, fbpost,
                    Character,
                    CharBRender, CharWRender;
    UILabel fb;
    public UILabel deathLbl, timeLbl;
    public Material BlackMat, WhiteMat;
    public static GameState gameState = GameState.OpeningWindow;
    public static CurrentPlayMode currentPlayMode = CurrentPlayMode.Black;
    private bool toggle;
    public bool cheats;
    private int deaths;
    private float time, maxTime;

    #endregion

    //#region Mono Inherit Functions

    //void Awake () {
    //    BlackMat.color = new Color(BlackMat.color.r, BlackMat.color.g, BlackMat.color.b, 1f);
    //    WhiteMat.color = new Color(WhiteMat.color.r, WhiteMat.color.g, WhiteMat.color.b, 1f);
    //    gameState = GameState.OpeningWindow;
    //    OpeningWindow.SetActiveRecursively(true);
    //    GameOverWindow.SetActiveRecursively(false);
    //    SelectionWindow.SetActiveRecursively(false);
    //    TutorialWindow.SetActiveRecursively(false);
        

    //    BlackCam.camera.rect = new Rect(0.5f, 0, 0.5f, 1);
    //    WhiteCam.camera.rect = new Rect(0, 0, 0.5f, 1);

    //    MainCam.camera.rect = new Rect(0, 0, 1, 1);
    //    MainCam.active = Facebook.active = true;
    //    BlackCam.active = WhiteCam.active = fbsuccess.active = false;
    //    fb = fbsuccess.GetComponent<UILabel>();

    //    deathLbl.text = "You died: @ time(s)!";
    //    timeLbl.text = "Your max time: @";
    //}
	
    //void Update ()
    //{

    //    #region Fade in/out
    //    if (toggle)
    //    {
    //        if (GameManager.currentPlayMode == CurrentPlayMode.Black)
    //        {
    //            if (Toggle(ref WhiteMat, true)&&Toggle(ref BlackMat, false))
    //            {
    //                toggle = false;
    //                ActivateBlackMode(false);
    //                GameManager.currentPlayMode = CurrentPlayMode.White;
    //            }
    //        }
    //        else if (GameManager.currentPlayMode == CurrentPlayMode.White)
    //        {
    //            if(Toggle(ref BlackMat, true)&& Toggle(ref WhiteMat, false))
    //            {
    //                toggle = false;
    //                ActivateWhiteMode(false);
    //                GameManager.currentPlayMode = CurrentPlayMode.Black;
    //            }
    //        }
    //    }
    //    #endregion
    //}

    //#endregion

    #region UI Events

    void PlayHit()
    {
        Debug.Log("Play");
    }

    #endregion

    #region Utilities

    #endregion


}
