using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour 
{
	public StateMachine<NPC> FSMenemy = new StateMachine<NPC>();
	
	public GameObject player;
	
	[HideInInspector]
	public bool foundPlayer;
	
	private Vector3 target;
	private Vector3 targetDistance;
	
	// Use this for initialization
	void Start () {
		foundPlayer = false;
		if(player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}
		
		FSMenemy.Configure(this, Seek.Instance);
	}
	
	// Update is called once per frame
	void Update () {
		FSMenemy.Update();
		
		target = player.transform.position;
		targetDistance = transform.position - target;
	}
	
	public bool SearchPlayer()
	{
		if(targetDistance.magnitude <= 25)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
