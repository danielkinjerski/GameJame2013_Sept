using UnityEngine;
using System.Collections;

public class EnemyMovement : BaseMovement 
{
    public StateMachine<EnemyMovement> FSM = new StateMachine<EnemyMovement>();

    public override Vector2 InputMovement()
    {
        if (FSM.CurrentState == Seek.Instance)
        {
            Vector3 targetDir = (trans.position - target.position).normalized;
            return new Vector2(targetDir.x, targetDir.z);
        }
        else
        {
            //print("stop");
            return Vector2.zero;
        }
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
