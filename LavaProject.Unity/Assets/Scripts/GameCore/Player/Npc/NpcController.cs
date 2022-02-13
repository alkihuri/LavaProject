using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NpcController : MonoBehaviour
{

    [SerializeField] GameObject _tower;
    TowerController _towerController;
    NavMeshAgent _npc; 
    [SerializeField] GameObject _particles;
    public UnityEvent OnDie = new UnityEvent();
    [SerializeField] bool _isLookingForPlayer;
    // Start is called before the first frame update
    void Start()
    {
        _isLookingForPlayer = true;
        _npc = GetComponent<NavMeshAgent>();
         _towerController = _tower.GetComponent<TowerController>();
        if(!_isLookingForPlayer)
            _npc.SetDestination(_towerController.FirePoint);
        OnDie.AddListener(Die);
    }

    public void Die()
    {
        GetComponent<NpcHealthController>().TakeDamage(51);
    }

    private void OnDestroy()
    {
        GameObject particles = Instantiate(_particles, transform.position, transform.rotation);
        Destroy(particles, 1);
    }

    public void SetDestination(Vector3 point)
    {
        //if (!_isLookingForPlayer)
        //    return;
        Debug.DrawLine(transform.position, point, Color.red);
        _npc.SetDestination(point);
    }
}
