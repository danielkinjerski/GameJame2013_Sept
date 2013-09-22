using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour
{
    public GameManager gm;
    public string MainLevel, PlayLevel;

    void QuitToMain()
    {
        Application.LoadLevel(MainLevel);
        Destroy(gm.gameObject);
    }

    void Replay()
    {
        Application.LoadLevel(PlayLevel);
    }
}
