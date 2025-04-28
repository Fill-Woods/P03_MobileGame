using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    private GameController _controller;

    


    //state variables here
    public GameSetupState SetupState { get; private set; }
    public GamePlayState PlayState { get; private set; }
    public GameEndedState EndedState { get; private set; }
    public GamePauseState PauseState { get; private set; }

    private void Awake()
    {
        _controller = GetComponent<GameController>();
        //state instantiation here
        SetupState = new GameSetupState(this, _controller);
        PlayState = new GamePlayState(this, _controller);
        EndedState = new GameEndedState(this, _controller);
        PauseState = new GamePauseState(this, _controller);


    }
    private void Start()
    {
        ChangeState(SetupState);
    }

}
