using UnityEngine;
using System.Collections;

public class BaseMovement : MonoBehaviour {

    public float maxSpeed, speed, targetSpeed;
    public float weight, gravity, accelerationRate;
    public float downwardForce = 0;
    public Transform trans;
    public Transform target;
    float threshold = 0;

    public StateMachine<BaseMovement> movementSM = new StateMachine<BaseMovement>();

    public CharacterController cc;

    public virtual void Start()
    {
        trans = transform;

        if (cc == null && GetComponent<CharacterController>())
            cc = GetComponent<CharacterController>();

        //entity = GetComponent<BaseEntity>();

        
        movementSM.Configure(this, Idle.Instance);
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
        moveDir = new Vector3(moveDir.x, downwardForce, moveDir.z) * Time.smoothDeltaTime;
    }

    public virtual Vector2 InputMovement()
    {
        return Vector2.zero;
    }

    public void ApplyVelocity(ref Vector3 moveDir)
    {
        targetSpeed = (moveDir.magnitude != 0) ? maxSpeed : 0;

        //This is our "friction"
        speed = Mathf.Lerp(speed, targetSpeed, accelerationRate);

        // If we've got a signification magnitude, continue moving forward ;; if were are recieving movement, apply it 
        moveDir = moveDir * speed;
    }

    public void CorrectDirection(ref Vector3 moveDir)
    {
        //Prevent snapping forward
        if (moveDir.magnitude == 0)
            moveDir = new Vector3(trans.forward.x, 0, trans.forward.z);

        if (speed > 0.9f)
            trans.forward = new Vector3(moveDir.x, 0, moveDir.z);

        // if we're turning around, snap backwards
        if (Vector3.Dot(new Vector3(moveDir.x, 0, moveDir.z), trans.forward) < .5f)
            trans.forward = Vector3.Lerp(trans.forward, new Vector3(moveDir.x, 0, moveDir.z), 1 / speed);
        else
            trans.forward = new Vector3(moveDir.x, 0, moveDir.z);

        if (moveDir.magnitude == 0)
            moveDir = trans.forward * speed;

    }


    float CheckDistanceToTarget()
    {
        if(target != null)
        {
            return (target.position - trans.position).magnitude;
        }
        return threshold;
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
