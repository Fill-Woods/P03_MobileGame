using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public float StateDuration { get; private set; } = 0;

    //run once when state is Entered
    public virtual void Enter()
    {
        StateDuration = 0;
    }

    //run once when state is Exited
    public virtual void Exit()
    {

    }

    //for Physics
    public virtual void FixedTick()
    {

    }

    //for Update
    public virtual void Tick()
    {
        StateDuration += Time.deltaTime;
    }
}
