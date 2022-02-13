using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NpcStateMachine : MonoBehaviour
{ 
    public UnityEvent OnStateChanged = new UnityEvent(); 
    NpcState _currentState;
    public void SetState (NpcState.CurrentState _stateToSet)
    {
        _currentState = new NpcState(_stateToSet);
        OnStateChanged.Invoke();
    }
}
