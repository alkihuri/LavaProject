using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IStateMachine  
{
    public void SetState(StateSettings.CurrentState state);
}
