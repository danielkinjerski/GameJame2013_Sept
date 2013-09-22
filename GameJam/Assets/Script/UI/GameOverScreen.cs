using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour
{
    public GameManager gm;
    public string MainLevel, PlayLevel;
    public UILabel summary;

    void Start()
    {
        Results(gm.virusCount.ToString(), gm.whiteBloodCount.ToString()) ;
    }


    void QuitToMain()
    {
        Application.LoadLevel(MainLevel);
        Destroy(gm.gameObject);
    }

    void Replay()
    {
        Application.LoadLevel(PlayLevel);
    }

    void Results(string vcell, string wcell)
    {
        summary.text = summary.text.Replace("[vcell]", vcell);
        summary.text = summary.text.Replace("[wcell]", wcell);
    }
}
