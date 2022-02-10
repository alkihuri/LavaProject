using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContreoller : MonoBehaviour
{

    GameObject _target;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] GameObject _particles;
    [SerializeField,Range(0,100)] float _timeToDie = 3;
    private float  _power = 10;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false; 
        Destroy(gameObject, _timeToDie);
    }

    private void FixedUpdate()
    {  
        if(_target != null)
        {
            Vector3 v1 = transform.position;
            Vector3 v2 = _target.transform.position;
            Vector3 v3 = v2 - v1;
            _rigidbody.AddForce(v3 * _power);
        }
        else
        {
            _rigidbody.AddForce(transform.forward * _power);
        }

    }

   

    public  void SetDestination(GameObject position)
    {
        _rigidbody.isKinematic = false; 
        _target = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NpcController>())
            other.gameObject.GetComponent<NpcController>().OnDie?.Invoke();
        if(!_rigidbody.isKinematic)
            Destroy(gameObject); 
    }
    private void OnDestroy()
    {
        GameObject particles = Instantiate(_particles,transform.position,transform.rotation);
        Destroy(particles, 1);
    }
}
