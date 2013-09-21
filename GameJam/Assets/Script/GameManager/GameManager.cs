using UnityEngine;
using System.Collections;

public class GameManager: MonoBehaviour 
{
	
	private GameObject Door;
	private bool won;
	private bool death;
	public GUIStyle guiStyle;
	public string NextLevel;
	
	public int totalCoin;
	public int foundCoin;

	void Start () 
	{
		Time.timeScale = 1.0f;
		totalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
		Door = GameObject.Find("Door");
		
	}
	
	void Updata()
	{
		if (Input.GetKey (KeyCode.X))
		{
			Application.LoadLevel("Main_Menu");
		}
	}
	
	void OnGUI () 
	{
		if (GUI.Button(new Rect(10, Screen.height - 25, 50, 20), "Menu"))
		{            
			Application.LoadLevel("Main_Menu");
		}
		
		if (won) 
		{
			GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 150, 100, 20), "You Won", guiStyle);
			if(NextLevel != "Main_Menu")
			{
				if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 130, 100, 20), "Next Level"))
				{            
					Application.LoadLevel(NextLevel);
				}
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 105, 100, 20), "Menu"))
			{            
				Time.timeScale = 1f;
				Application.LoadLevel("Main_Menu");
			}
		}
		
		else if (death) 
		{
			GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 150, 100, 20), "FAIL", guiStyle);
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 130, 100, 20), "Try Again"))
			{            
				Application.LoadLevel(Application.loadedLevelName);
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 105, 100, 20), "Menu"))
			{            
				Application.LoadLevel("Main_Menu");
			}
		}
		GUI.Label(new Rect(10, 10, 500, 20), "Found Coins: "+foundCoin+"/"+totalCoin, guiStyle);
	}
	
	public void FoundCoin()
    {
		
        foundCoin++;
		
        if (foundCoin >= totalCoin)
        {
            Door.GetComponent<Door>().FindAllCoin = true;
        }
    }
	

	
	public void Won()
	{
		Time.timeScale = 0f;
		won = true;
	}
	
	public void Death()
	{
		Screen.showCursor = true;
		Screen.lockCursor = false;
		death = true;
	}
}
