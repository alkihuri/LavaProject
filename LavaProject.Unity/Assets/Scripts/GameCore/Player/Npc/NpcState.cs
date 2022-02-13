using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcState
{
    public enum CurrentState
    { 
        Idle,
        Run,
        Attack
    
    }

    public NpcState(CurrentState stateToSet)
    {
        _currentState = stateToSet;
    }


    private CurrentState _currentState;
}
