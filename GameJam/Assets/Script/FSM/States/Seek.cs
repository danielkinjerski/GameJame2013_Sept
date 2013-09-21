using UnityEngine;
using System.Collections;

public class Seek : State<EnemyMovement> 
{
    static readonly Seek instance = new Seek();
    public static Seek Instance {get {return instance;}}
    static Seek() { }
    private Seek() { }

    public override bool Enter(EnemyMovement bm)
    {
        //base.Enter();
        return true;
    }

    public override bool Execute(EnemyMovement bm)
    {
        if (bm.CheckDistanceToTarget() > bm.seekThreshold)
        {
            bm.FSM.ChangeState(Idle.Instance);
            return true;
        }

        if (bm.CheckDistanceToTarget() < bm.attackThreshold)
        {
            //bm.FSM.ChangeState(Attacking.Instance);
            return true;
        }

        Vector3 dir = bm.MoveForward();
        bm.cc.Move(dir * Time.smoothDeltaTime);
		
        return true;
    }

    public override bool Exit(EnemyMovement bm)
    {
        //base.Exit();
        return true;
    }

}
