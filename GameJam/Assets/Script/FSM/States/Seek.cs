using UnityEngine;
using System.Collections;

public class Seek : State<NPC> 
{
    static readonly Seek instance = new Seek();
    public static Seek Instance {get {return instance;}}
    static Seek() { }
    private Seek() { }

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

}
