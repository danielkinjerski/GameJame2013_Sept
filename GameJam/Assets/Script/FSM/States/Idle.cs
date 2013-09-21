using UnityEngine;
using System.Collections;

public class Idle : State<EnemyEntity>
{
    static readonly Idle instance = new Idle();
    public static Idle Instance { get { return instance; } }
    static Idle() { }
    private Idle() { }

    public override bool Enter(EnemyEntity bm)
    {
        return true;
    }

    public override bool Execute(EnemyEntity bm)
    {
        if (bm.CheckDistanceToTarget() != 0 && bm.CheckDistanceToTarget() < bm.seekThreshold)
        {
            bm.FSM.ChangeState(Seek.Instance);
        }

        return true;
    }

    public override bool Exit(EnemyEntity bm)
    {
        return true;
    }
}
