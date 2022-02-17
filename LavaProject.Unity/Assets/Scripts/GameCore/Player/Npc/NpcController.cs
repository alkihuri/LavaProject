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
    [SerializeField] bool _isLookingForPlayer;
    // Start is called before the first frame update
    void Start()
    { 
        _isLookingForPlayer = true;
        _npc = GetComponent<NavMeshAgent>();   
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
            GetComponent<NpcStateMachine>().SetState( new RunAjdaha() );
    }

    public void  GiveDamage(float _power)
    {
        GetComponent<NpcHealthController>().TakeDamage(_power);
    }



    
}
