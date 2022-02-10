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
    // Start is called before the first frame update
    void Start()
    {
        _npc = GetComponent<NavMeshAgent>();
         _towerController = _tower.GetComponent<TowerController>();
        _npc.SetDestination(_towerController.FirePoint);
        OnDie.AddListener(Die);
    }

    public void Die()
    {
        GetComponentInChildren<Animator>().enabled = false;
        Destroy(gameObject, 5);
    }

    private void OnDestroy()
    {
        GameObject particles = Instantiate(_particles, transform.position, transform.rotation);
        Destroy(particles, 1);
    }
}
