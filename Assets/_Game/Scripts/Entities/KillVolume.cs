using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolume : MonoBehaviour
{
    private GameFSM _stateMachine;

    private void Start()
    {
        _stateMachine = FindObjectOfType<GameFSM>();
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Player"))
            { 
                _stateMachine.ChangeState(_stateMachine.EndedState);
            } 
    }

}
