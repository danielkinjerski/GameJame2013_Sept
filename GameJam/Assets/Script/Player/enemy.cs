using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour 
{
	public GameObject prefab;
	public Texture2D normal;
	public Texture2D protect1;
	public Texture2D protect2;
	public Texture2D protect3;
	
	public int minRandom;
	public int maxRandom;
	
	public bool playerAttacked;
	
	private int waitTime;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(changeProtection());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	
	IEnumerator changeProtection()
	{
		yield return new WaitForSeconds(waitTime);
		//ChangeMaterial();
	}
}
