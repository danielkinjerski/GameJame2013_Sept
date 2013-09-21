using UnityEngine;
using System.Collections;

public class PlayerEntity : BaseEntity
{

    public override Vector2 InputMovement()
    {
        Vector3 dir = Camera.main.transform.forward * Input.GetAxis("Vertical") + Input.GetAxis("Horizontal") * Camera.main.transform.right;
        Vector2 dir2 = new Vector2(dir.x, dir.z);
        return dir2.normalized;
    }
}
