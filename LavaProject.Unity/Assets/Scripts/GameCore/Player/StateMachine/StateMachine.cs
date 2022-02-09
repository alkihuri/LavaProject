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
    public UnityEvent OnStateChange = new UnityEvent();
    private void Start()
    {
        _player = GetComponent<NavMeshAgent>();
        OnStateChange.AddListener(SetState);
    }

    public void SetState()
    {
       _player.speed =  _stateToSet.CHARACTER_SPEED;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            OnStateChange?.Invoke();
    }
}
