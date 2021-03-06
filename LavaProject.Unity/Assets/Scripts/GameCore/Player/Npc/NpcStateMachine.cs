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

    private void Awake()
    {
        OnAttackState.AddListener(AudioManager.Instance.PlayExplosion);
    }
    private void Start()
    {
        SetState(new IdleAjdaha());
    }

    public void SetState(NpcState stateToSet)
    {

        _currentState = stateToSet.ApllyState();                 

        if (!(_currentState is AjdahaState))                     
            return;          
        _state = ((AjdahaState)_currentState).state;           
        if (stateToSet is AttackAjdaha)  
            OnAttackState.Invoke();
        if (stateToSet is RunAjdaha)
            OnRunState.Invoke();
    }
}
