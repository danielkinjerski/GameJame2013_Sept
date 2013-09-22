using UnityEngine;
using System.Collections;

public class AIHealth : MonoBehaviour 
{
	public Texture2D infected;
	public int health = 100;
	public float regenHealthTime = 1f;
	public int damageTaken = 20;
	public int regenAmount = 10;
	
	GameObject player;
	bool isTakingDamage;
	
	void Update () {
		//if player collides with enemy[T-cell], press space to do damage
		if(isTakingDamage && Input.GetKeyDown(KeyCode.Space))
		{
			health -= damageTaken;
			StartCoroutine(Regenerate());
		}
		
		if(health <= 0)
		{
			Destroy(this.gameObject);
		}
	}
	
	IEnumerator Regenerate()
	{
		yield return new WaitForSeconds(regenHealthTime);
		health += regenAmount;
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			isTakingDamage = true;
			Debug.Log("is hitting");
		}
    }
	
	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			isTakingDamage = false;
		}
    }
}
