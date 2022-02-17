using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using StateSettings;

public class NpcStateMachine : MonoBehaviour,IStateMachine
{ 
    public UnityEvent OnAttackState = new UnityEvent();
    public UnityEvent OnIdleState   = new UnityEvent();
    public UnityEvent OnRunState    = new UnityEvent();

    object _currentState;
    public State _state;

    public void SetState(NpcState stateToSet)
    {
        _currentState =  stateToSet.ApllyState();
        _state = (NpcState)_currentState;
        if (stateToSet is AttackAjdaha)
            OnAttackState.Invoke();
        if (stateToSet is RunAjdaha)
            OnRunState.Invoke();
    }
}
