using UnityEngine;
using System.Collections;

public class PlayerEntity : BaseEntity
{
 	public int damage;
	
    public override Vector2 InputMovement()
    {
        Vector3 dir = Camera.main.transform.up * (Input.GetAxis("Vertical") + Input.GetAxis("Joy1 Axis 2")) + (Input.GetAxis("Horizontal") + Input.GetAxis("Joy1 Axis 1")) * Camera.main.transform.right;
        Vector2 dir2 = new Vector2(dir.x, dir.z);
        return dir2.normalized;
    }

    void Update()
    {
        Vector3 dir = MoveForward();
        if(speed != 0)
            rb.velocity = dir;
    }

    void OnCollisionStay(Collision col)
    {
      
        if(col.gameObject.CompareTag("Enemy"))
        {
            if(Input.GetKeyDown(KeyCode.Space) || 
                Input.GetKeyDown(KeyCode.Joystick1Button0) ||
                Input.GetKeyDown(KeyCode.Joystick1Button1) ||
                Input.GetKeyDown(KeyCode.Joystick1Button2) ||
                Input.GetKeyDown(KeyCode.Joystick1Button3))
			{
				//Debug.Log("loaoaoa shit");
				col.gameObject.SendMessage("ApplyDamage",damage);
			}
        }
    }
	
}
