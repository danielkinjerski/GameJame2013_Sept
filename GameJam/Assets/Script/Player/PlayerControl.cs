using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
	private GameObject _GameManager;
	public Vector3 movement;
	public float moveSpeed = 6.0f;
	public float jumpSpeed = 5.0f;
	public float drag = 2;
	private bool canJump = true;
	
	void Start()
	{
		_GameManager = GameObject.Find("_GameManager");
	}
	
	void Update () 
	{	
		Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
		forward.y = 0;
		forward = forward.normalized;
		
		Vector3 forwardForce = new Vector3();
		if (Application.platform == RuntimePlatform.Android) 
		{
			
			forwardForce = forward * 1f * moveSpeed;
		}
		else
		{
			forwardForce = forward * Input.GetAxis("Vertical") * moveSpeed;
		}
		rigidbody.AddForce(forwardForce);
		
		Vector3 right= Camera.main.transform.TransformDirection(Vector3.right);
		right.y = 0;
		right = right.normalized;
		
		Vector3 rightForce = new Vector3();
		if (Application.platform == RuntimePlatform.Android) 
		{
		
			rightForce = right * 0.8f * moveSpeed;
		}
		else
		{
			rightForce= right * Input.GetAxis("Horizontal") * moveSpeed;
		}		
		rigidbody.AddForce(rightForce);
				
		/*if (canJump && Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody.AddForce(Vector3.up * jumpSpeed * 100);
			canJump = false;
		
		}*/
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Destroy")
		{
			_GameManager.GetComponent<GameManager>().Death();
			Destroy(gameObject);
		}
		else if (other.tag == "Coin")
		{
			Destroy(other.gameObject);
			_GameManager.GetComponent<GameManager>().FoundCoin();
		}
		else if (other.tag == "SpeedBooster")
		{
			movement = new Vector3(0,0,0);
			
		}
		else if (other.tag == "JumpBooster")
		{
			movement = new Vector3(0,0,0);
			
		}
		else if (other.tag == "Teleporter")
		{
			movement = new Vector3(0,0,0);
			
		}
    }
	
	/*
	void OnCollisionEnter(Collision collision)
	{
		if (!canJump)
		{
			canJump = true;
			
		}
    }*/
	
}
