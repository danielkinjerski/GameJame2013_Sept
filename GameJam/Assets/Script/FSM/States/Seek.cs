using UnityEngine;
using System.Collections;

public class Seek : State<EnemyEntity> 
{
    static readonly Seek instance = new Seek();
    public static Seek Instance {get {return instance;}}
    static Seek() { }
    private Seek() { }

    public override bool Enter(EnemyEntity bm)
    {
        Debug.Log("Seek");
        return true;
    }

    public override bool Execute(EnemyEntity bm)
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
        bm.cc.Move(dir);
		
        return true;
    }

    public override bool Exit(EnemyEntity bm)
    {
        //base.Exit();
        return true;
    }

}
