using UnityEngine;
using System.Collections;

public class BaseEntity
{};

public class Seek : State<BaseEntity> 
{
    static readonly Seek instance = new Seek();
    public static Seek Instance {get {return instance;}}
    static Seek() { }
    private Seek() { }

    protected virtual void Start()
    {
        //base.Start();
    }

    public override bool Enter(BaseEntity e)
    {
        //base.Enter();
        return true;
    }

    public override bool Execute(BaseEntity e)
    {
        //base.Execute();
        //e.movement.BasicPhysics();

       /* if (e.movement.target != null)
        {
            if (e.movement.GetDistanceFromTarget(e.movement.target) > 2)
           {
               if ((e.movement as AIMovement).CanSeeTarget() && e.movement.GetHeightDifference(e.movement.target) < 3 && !(e.movement as AIMovement).CheckForPits(1, 2))
               {
                   (e.movement as AIMovement).FaceTarget(e.movement.target.transform);
               }
               else if (!(e.movement as AIMovement).CanSeeTarget() || (e.movement as AIMovement).CheckForPits(1, 2))
               {
                   e.abilitiesSM.ChangeState(Idle.Instance);
                   //movement.Stop();
               }
            }
            else if (e.movement.GetDistanceFromTarget(e.movement.target) <= 3 && e.movement.GetHeightDifference(e.movement.target) < 3)
            {

                if ((e.movement as AIMovement).CanSeeTarget())
                {
                    e.abilitiesSM.ChangeState(SimpleAttack.Instance);
                }
            }
            else
            {
                e.abilitiesSM.ChangeState(Idle.Instance);
                //Debug.Log("Is this even being called?");
            }
        }*/

        //if (Input.GetKeyDown(KeyCode.Space) && !movement.justJumped)
        //{ movement.Jump(); }

        //if (e.movement.justLanded)
        //{
        //    e.abilitiesSM.ChangeState(Landing.Instance);
        //}

        //RaycastHit hit;
        //if (Physics.Raycast(e.transform.position, e.transform.forward, out hit, 1))
        //{
        //    //e.rigidbody.velocity += new Vector3(0, 2, 0);
        //    Debug.Log("Slope");
        //}


        //If there is an obstacle in the way
        /*if ((e.movement as AIMovement).CheckForObstacles(4, 0))
        {
            if ((e.movement as AIMovement).CheckForObstacles(4, 1))
            {
                //if (movement.canJumpOverObstacles)
                //    movement.Jump(10);

            }
            else if ((e.movement as AIMovement).CheckForObstacles(2, 2))
            {
                //if (movement.CanSeeTarget())
                //{
                e.movement.RotateTowards(e.movement.target.position);
                    //e.movement.Stop();
                //}
            }
        }*/

        //AnimHandler(e);
        return true;
    }

    public override bool Exit(BaseEntity e)
    {
        //base.Exit();
        return true;
    }

    public void AnimHandler(BaseEntity e)
    {
        //if (e.movement.groundedState == BaseEntityMovement.GroundedState.Grounded)
        //{
        //    if (e.movement.speed == 0)
        //    {
        //        e.animation.Play("idle");
        //    }
        //    else if (e.movement.speed > e.movement.targetSpeed / 2)
        //    {
        //        e.animation.Play("run");
        //    }
        //}
        //else if (e.movement.groundedState == BaseEntityMovement.GroundedState.Falling)
        //{
        //    e.animation.Play("fall");
        //}
        //else
        //{
        //    e.animation.Play("jump");
        //}
    }
}
