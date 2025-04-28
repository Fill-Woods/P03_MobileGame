using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("STATE: Game Play!");
        Time.timeScale = 1f;
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void FixedTick()
    {
        base.FixedTick();
    }
    public override void Tick()
    {
        base.Tick();
        
        //check for lose condition
        if(StateDuration >= _controller.TapLimitDuration)
        {
            Debug.Log("You Lose!");
            //Lose State, reload level, change back to SetupState, etc.
            _stateMachine.ChangeState(_stateMachine.EndedState);
        }
    }
}

