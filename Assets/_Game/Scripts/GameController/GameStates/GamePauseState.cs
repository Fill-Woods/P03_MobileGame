using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GamePauseState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePauseState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
        
    }
    public override void Enter()
    {
        base.Enter();

        Debug.Log("STATE: Game Paused");
        Time.timeScale = 0f;

        //_pauseMenuEvent.ShowPauseMenu();
    }
    public override void Exit()
    {
        base.Exit();
        //_pauseMenuEvent.HidePauseMenu();
    }
    public override void FixedTick()
    {
        base.FixedTick();
    }
    public override void Tick()
    {
        base.Tick();
    }
}

