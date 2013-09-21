using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour 
{
	public Transform player;
	public Transform[] waypoints;
	public float speed = 8f;
	public float lookRadius = 15f;
	public float chase = .6f;
	//public bool loop = true;
	
	private int currentWaypoint;
	private Vector3 target;
	private Vector3 moveDirection;
	private Vector3 velocity;
	private Vector3 distancePlayer;
	
	void Start()
	{
		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		
		if(player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player").transform;
		}
	}
	
	void Update()
	{
		if(currentWaypoint < waypoints.Length)
		{
			target = waypoints[currentWaypoint].position;
			moveDirection = target - transform.position;
			distancePlayer = player.position - transform.position;
			
			velocity = rigidbody.velocity;
			transform.LookAt(waypoints[currentWaypoint]);
			
			if(moveDirection.magnitude < 1)
			{
				currentWaypoint = Random.Range(0, waypoints.Length);
			}
			//player is certain distance from AI
			else if(distancePlayer.magnitude < lookRadius)
			{
				transform.LookAt(player);
				RaycastHit hit;
				
				//fires a raycast and if player hits raycast than AI chase player
				if (Physics.Raycast(transform.position, transform.forward, out hit, 150f))
				{
					if(hit.transform.gameObject.CompareTag("Player"))
					{
						velocity = Vector3.zero;
						velocity = (player.position - transform.position) * chase;
						if(distancePlayer.magnitude > 1 && distancePlayer.magnitude < 3)
						{
							velocity = Vector3.zero;
						}
					}
					
				}
			}
			else
			{
				velocity = moveDirection.normalized * speed;
			}
		}
		/*else
		{
			//loops through the waypoints
			if(loop)
			{
				currentWaypoint = 0;
			}
			else
			{
				velocity = Vector3.zero;
			}
		}*/
		
		rigidbody.velocity = velocity;
	}
}
