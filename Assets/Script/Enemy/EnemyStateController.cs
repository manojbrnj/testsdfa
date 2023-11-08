using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController 
{
    public EnemyStates _currentState;
    public void InitializeState(EnemyStates _startState)
    {
        _currentState = _startState;
        _currentState.Enter();
    }
   public void ChangeState(EnemyStates _newState)
    {
        _currentState.Exit();
        _currentState = _newState;
        _currentState.Enter();
    }
}
