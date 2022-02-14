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
    public NpcState _currentState; 
    private void Start()
    {
        SetState( CurrentState.Idle);
    }

    public void SetState ( CurrentState _stateToSet)
    {
        _currentState = new NpcState(_stateToSet); 

        switch (_stateToSet)
        {
            case CurrentState.Idle:
                OnIdleState.Invoke();
            break;

            case CurrentState.Run:
                OnRunState.Invoke();
            break;

            case CurrentState.Attack:
                OnAttackState.Invoke();
            break;

            default:
                OnIdleState.Invoke();
            break;
                 
        }

    }
}
