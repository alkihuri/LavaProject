using StateSettings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IStateMachine  
{
    public void SetState(NpcState _stateToSet);
}
