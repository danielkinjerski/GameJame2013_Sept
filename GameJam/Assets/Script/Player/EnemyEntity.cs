using UnityEngine;
using System.Collections;

public class EnemyEntity : BaseEntity 
{
    public StateMachine<EnemyEntity> FSM = new StateMachine<EnemyEntity>();

    public Transform target;
    public float seekThreshold = 0;
    public float attackThreshold = 0;

    public void Start()
    {
        base.Start();
        FSM.Configure(this, Idle.Instance);
    }


    public override Vector2 InputMovement()
    {
        if (FSM.CurrentState == Seek.Instance)
        {
            Vector3 targetDir = (target.position - trans.position).normalized;
            return new Vector2(targetDir.x, targetDir.z);
        }
        else
        {
            //print("stop");
            return Vector2.zero;
        }
    }

    public void Update()
    {
        FSM.Update();
    }
    


    public float CheckDistanceToTarget()
    {
        if (target != null)
        {
            return (target.position - trans.position).magnitude;
        }
        return seekThreshold;
    }
}
