using UnityEngine;
using System.Collections;

public class Idle : State<BaseMovement>
{
    static readonly Idle instance = new Idle();
    public static Idle Instance { get { return instance; } }
    static Idle() { }
    private Idle() { }

    public override bool Enter(BaseMovement bm)
    {
        return true;
    }

    public override bool Execute(BaseMovement bm)
    {
        // Play idle anim

        return true;
    }

    public override bool Exit(BaseMovement bm)
    {
        return true;
    }
}
