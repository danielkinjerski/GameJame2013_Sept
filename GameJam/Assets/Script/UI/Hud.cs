using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour {

    public GameManager gm;
    public UILabel time, whiteBlood, virusCells;

	// Use this for initialization
	void Start () {
        gm.onTimerIncrement += gm_onTimerIncrement;
	}

    void gm_onTimerIncrement(string text)
    {
        time.text = text;
    }
}
