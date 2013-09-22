using UnityEngine;
using System.Collections;

public class PlayerEntity : BaseEntity
{
 	public int damage;
	
    public override Vector2 InputMovement()
    {
        Vector3 dir = Camera.main.transform.forward * Input.GetAxis("Vertical") + Input.GetAxis("Horizontal") * Camera.main.transform.right;
        Vector2 dir2 = new Vector2(dir.x, dir.z);
        return dir2.normalized;
    }

    void Update()
    {
        Vector3 dir = MoveForward();
        if(speed != 0)
            cc.Move(dir);
    }
	
	void OnCollisionStay(Collision collision)
	{
		if(collision.gameObject.CompareTag("Enemy"))
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				print("attack");
				collision.gameObject.SendMessage("ApplyDamage", damage);
			}
		}
	}
}
