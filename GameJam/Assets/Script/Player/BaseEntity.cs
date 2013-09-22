using UnityEngine;
using System.Collections;

public class BaseEntity : MonoBehaviour {

    public float gravity = 9, maxSpeed = 5, accelerationRate = .1f;
    protected float speed, targetSpeed;
    float downwardForce = 0;
    protected Transform trans;
    public CharacterController cc;
    public Rigidbody rb;

    public virtual void Start()
    {
        trans = transform;

        if (cc == null && GetComponent<CharacterController>())
            cc = GetComponent<CharacterController>();

        rb = GetComponent<Rigidbody>();
    }

    public Vector3 MoveForward()
    {
        Vector2 input = InputMovement();
        Vector3 dir = new Vector3(input.x, 0, input.y);
        dir.Normalize();
        ApplyVelocity(ref dir);
        CorrectDirection(ref dir);
        ApplyGravity(ref dir);        
        return dir;
    }

    public void ApplyGravity(ref Vector3 moveDir)
    {
        if (downwardForce > -gravity)
            downwardForce += -gravity * Time.smoothDeltaTime;
        moveDir = new Vector3(moveDir.x, downwardForce, moveDir.z);
    }

    public virtual Vector2 InputMovement()
    {
        return Vector2.zero;
    }

    public void ApplyVelocity(ref Vector3 moveDir)
    {
        targetSpeed = (moveDir.magnitude > .01f) ? maxSpeed : 0;

        //This is our "friction"
        speed = Mathf.Lerp(speed, targetSpeed, accelerationRate);

        if (speed < .01f)
            speed = 0;

        // If we've got a signification magnitude, continue moving forward ;; if were are recieving movement, apply it 
        moveDir = moveDir * speed;
    }

    public void CorrectDirection(ref Vector3 moveDir)
    {
        if (moveDir.magnitude == 0)
            moveDir = trans.forward * speed;

        if (speed > 0.9f)
            trans.forward = new Vector3(moveDir.x, 0, moveDir.z);

        if ((new Vector2(moveDir.x, moveDir.z)).magnitude == 0)
            return;

        // if we're turning around, snap backwards
        if (Vector3.Dot(new Vector3(moveDir.x, 0, moveDir.z), trans.forward) < .5f)
            trans.forward = Vector3.Lerp(trans.forward, new Vector3(moveDir.x, 0, moveDir.z), 1 / speed);
        else
            trans.forward = new Vector3(moveDir.x, 0, moveDir.z);

    }

}
