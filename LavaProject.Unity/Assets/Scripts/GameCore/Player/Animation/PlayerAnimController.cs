using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimController : MonoBehaviour
{

    [SerializeField] string _animnBlendParam;
    Animator _animator;
    NavMeshAgent _player;
    // Start is called before the first frame update

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _player = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        var currentSpeed = Mathf.Clamp01(_player.velocity.magnitude);
        _animator.SetFloat(_animnBlendParam, currentSpeed);
    }
}