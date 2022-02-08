using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class StateMachine : MonoBehaviour
{
    [SerializeField] PlayerState _stateToSet;

    NavMeshAgent _player;

    public UnityEvent _onStateChange;
    private void Start()
    {
        _player = GetComponent<NavMeshAgent>();
        _onStateChange.AddListener(SetState);
    }

    public void SetState()
    {
       _player.speed =  _stateToSet.CHARACTER_SPEED;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SetState();
    }
}
