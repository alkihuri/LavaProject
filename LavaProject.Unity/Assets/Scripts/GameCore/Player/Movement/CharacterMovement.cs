using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    NavMeshAgent _player;
    [SerializeField] GameObject _someShit;
    RaycastManager _raycastManager;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<NavMeshAgent>();
        _raycastManager = GetComponent<RaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        
        
        
        _player.SetDestination(_raycastManager.GetDestinationPoint());
    }
}