using UnityEngine;
using System.Collections;

public class PlayerEntity : BaseEntity
{
 	public int damage;
	
    public override Vector2 InputMovement()
    {
        Vector3 dir = Camera.main.transform.up * Input.GetAxis("Vertical") + Input.GetAxis("Horizontal") * Camera.main.transform.right;
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
            if(Input.GetKeyDown(KeyCode.Space))
			{
				Debug.Log("loaoaoa shit");
				col.gameObject.SendMessage("ApplyDamage",damage);
			}
        }
    }
	
}
