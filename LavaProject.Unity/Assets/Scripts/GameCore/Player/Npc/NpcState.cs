using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NpcStateSetting
{

    
    public enum CurrentState
    {
        Idle,
        Run,
        Attack

    }
    [System.Serializable]
    public class NpcState
    {
         
        public NpcState(CurrentState stateToSet)
        {
            _currentState = stateToSet;
        }
        [SerializeField]
        public  CurrentState _currentState;
    }



}
