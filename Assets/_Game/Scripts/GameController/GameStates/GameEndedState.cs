using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameEndedState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private VisualElement _gameEndedVisualTree;

    public GameEndedState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("STATE: Game Ended");
        //this should be where the ui comes in

        
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
    }
}
