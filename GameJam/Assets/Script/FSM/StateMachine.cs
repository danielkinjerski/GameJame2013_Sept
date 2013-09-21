using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class StateMachine<T>
{
    #region Members
    private T Owner;
    public State<T> CurrentState;
    public State<T> PreviousState;
    //bool IsChangingState;
    #endregion

    public void Awake()
    {
        CurrentState = null;
        PreviousState = null;
    }

    public void Configure(T owner, State<T> InitialState)
    {
        Owner = owner;
        ChangeState(InitialState);
    }

    public void Update()
    {
        if (CurrentState == null)
            return;

        //if (IsChangingState)
        //{
        //    IsChangingState = false;
        //    return;
        //}

        if (!CurrentState.Execute(Owner))
        {
            RevertToPreviousState();
        }
    }

    public void ChangeState(State<T> NewState)
    {
        // going to assume you can't re-enter the same state
        if (NewState == null )// || CurrentState == NewState)
            return;

        //IsChangingState = true;

        // Make sure we have a current state
        if (CurrentState != null)
        {
            // if we can't exit properly,
            // should we not exit the state?
            if (!CurrentState.Exit(Owner))
                return;

            // Do not allow our current and previous to be the same
            if(CurrentState != NewState)
                PreviousState = CurrentState;
        }

        // Go ahead with the new state operations
        CurrentState = NewState;        
        if (!CurrentState.Enter(Owner))
        {
            RevertToPreviousState();
        }
    }

    public void RevertToPreviousState()
    {
        if (PreviousState != null)
            ChangeState(PreviousState);
    }
}
