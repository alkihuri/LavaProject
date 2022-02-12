using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CharacterMovement : MonoBehaviour
{
    NavMeshAgent _player; 
    RaycastManager _raycastManager;
    [SerializeField,Range(-1,1)]private float _vertical;
    [SerializeField, Range(-1, 1)] private float _horizontal;
    private Vector3 _destinationPoint;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<NavMeshAgent>();
        _raycastManager = GetComponent<RaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {


        InputDataHandler();
        ThirdPersonControl();
        TopViewControl();
        _player.SetDestination(_destinationPoint);
    }

    private void ThirdPersonControl()
    {
        _destinationPoint =  transform.position + transform.forward * _vertical + transform.right * _horizontal;
    }

    private void TopViewControl()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        _destinationPoint = _raycastManager.GetDestinationPoint() ;
    }

    private void InputDataHandler()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(_destinationPoint,Vector3.one);
    }
}

 
