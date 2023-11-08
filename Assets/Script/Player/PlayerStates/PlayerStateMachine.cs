using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerStates _currentState;

    public void InitializeState(PlayerStates _startState)
    {
        _currentState = _startState;
        _currentState.Enter();
    }

    public void ChangeState(PlayerStates _newState)
    {

        _currentState.Exit();
        _currentState = _newState;
        _currentState.Enter();
    }
}
