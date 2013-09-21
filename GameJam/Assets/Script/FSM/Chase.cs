using UnityEngine;
using System.Collections;

public class Chase : State<NPC> 
{
    static readonly Chase instance = new Chase();
    public static Chase Instance {get {return instance;}}
    static Chase() { }
    private Chase() { }

    protected virtual void Start()
    {
        //base.Start();
    }

    public override bool Enter(NPC e)
    {
        //base.Enter();
        return true;
    }

    public override bool Execute(NPC e)
    {
        
		
        return true;
    }

    public override bool Exit(NPC e)
    {
        //base.Exit();
        return true;
    }

    public void AnimHandler(NPC e)
    {
		
    }
}
