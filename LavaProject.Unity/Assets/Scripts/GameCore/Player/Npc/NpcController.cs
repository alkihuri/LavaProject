using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using StateSettings;

public class NpcController : MonoBehaviour
{
     
    NavMeshAgent _npc; 
    [SerializeField] GameObject _particles;
    bool _isLookingForPlayer;
    NpcStateMachine _stateMachine;
    NpcHealthController _npcHealthController;

    // Start is called before the first frame update
    void Start()
    { 
        _isLookingForPlayer = true;
        _npc = GetComponent<NavMeshAgent>();
        _stateMachine = GetComponent<NpcStateMachine>();
        _npcHealthController = GetComponent<NpcHealthController>();
    }


    private void OnEnable()
    {
        GameObject particles = Instantiate(_particles, transform.position, transform.rotation);
        Destroy(particles, particles.GetComponent<ParticleSystem>().duration);
    }
    private void OnDestroy()
    {
        GameObject particles = Instantiate(_particles, transform.position, transform.rotation);
        Destroy(particles, particles.GetComponent<ParticleSystem>().duration);
    }

    public void SetDestination(Vector3 point)
    {
         if (!_isLookingForPlayer)
                return;
        _npc.SetDestination(point);
        if (_npc.velocity.magnitude > 0)
           _stateMachine.SetState( new RunAjdaha());
    }

    public void  GiveDamage(float _power)
    {
        _npcHealthController.TakeDamage(_power);
    }



    
}
