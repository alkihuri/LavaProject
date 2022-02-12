using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContreoller : MonoBehaviour
{

    GameObject _target;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] GameObject _particles;
    [SerializeField,Range(0,100)] float _timeToDie = 2;
    private float  _power = 10;

    private void Start()
    {

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false; 
       
    }

    private void FixedUpdate()
    {  
        if(_target != null)
        {
            NpcTarget();
        }
        else
        {
            NoTarget();
        }

    }

    private void NoTarget()
    {
         
    }

    private void NpcTarget()
    {
        Vector3 v1 = transform.position;
        Vector3 v2 = _target.transform.position;
        Vector3 v3 = v2 - v1;
        _rigidbody.AddForce(v3 * _power );
    }


    public  void SetDestination(GameObject position)
    {
        _rigidbody.isKinematic = false; 
        _target = position; 
        Destroy(gameObject, _timeToDie);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NpcController>() && !_rigidbody.isKinematic)
            other.gameObject.GetComponent<NpcController>().OnDie?.Invoke();
        if(!_rigidbody.isKinematic  && other.gameObject.GetComponent<NpcController>())
            Destroy(gameObject); 
    }
    private void OnDestroy()
    {
        GameObject particles = Instantiate(_particles,transform.position,transform.rotation);
        Destroy(particles, 1);
    }
}
