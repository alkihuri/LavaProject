using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{

    [SerializeField] GameObject _tower;
    TowerController _towerController;
    NavMeshAgent _npc;
    // Start is called before the first frame update
    void Start()
    {
        _npc = GetComponent<NavMeshAgent>();
        _towerController = _tower.GetComponent<TowerController>();
        _npc.SetDestination(_towerController.FirePoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
