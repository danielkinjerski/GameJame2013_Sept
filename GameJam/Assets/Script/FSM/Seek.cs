using UnityEngine;
using System.Collections;

public class Seek : State<NPC> 
{
    static readonly Seek instance = new Seek();
    public static Seek Instance {get {return instance;}}
    static Seek() { }
    private Seek() { }

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
        if(e.SearchPlayer())	
		{
			e.FSMenemy.ChangeState(Chase.Instance);
		}
		
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
