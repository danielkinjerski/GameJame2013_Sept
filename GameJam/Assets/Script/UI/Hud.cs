using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour {

    public GameManager gm;
    public UILabel time, whiteBlood, virusCells;

	// Use this for initialization
	void Start () {
        gm.OnTimerIncrement += gm_onTimerIncrement;
        gm.OnVirusCellCountChange += gm_OnVirusCellCountChange;
        gm.OnWhiteBloodCountChange += gm_OnWhiteBloodCountChange;
	}

    void gm_OnWhiteBloodCountChange(string text)
    {
        whiteBlood.text = text;
    }

    void gm_OnVirusCellCountChange(string text)
    {
        virusCells.text = text;
    }

    void gm_onTimerIncrement(string text)
    {
        time.text = text;
    }
}
