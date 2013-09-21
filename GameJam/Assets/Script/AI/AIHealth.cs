using UnityEngine;
using System.Collections;

public class AIHealth : MonoBehaviour 
{
	public int health = 100;
	public float regenHealthTime = 1f;
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(Regenerate());
	}
	
	IEnumerator Regenerate()
	{
		yield return new WaitForSeconds(regenHealthTime);
		health = 100;
	}
}
