using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContreoller : MonoBehaviour
{

    GameObject _target;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] GameObject _particles;
    [SerializeField,Range(0,100)] float _timeToDie = 0.1f;
    private float _speed;
    private float _power;
    [SerializeField] AnimationCurve _sizeOverLife;
    private float distace;

    private void Start()
    {
        
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false; 
       
    }

    private void FixedUpdate()
    {

        if(!_rigidbody.isKinematic)
        {
            distace = Vector3.Distance(transform.position, _target.transform.position);
            transform.localScale = Vector3.one * _sizeOverLife.Evaluate(Mathf.Clamp(distace, 0, 1)); 
        }
        if (_target != null)
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
        _rigidbody.AddRelativeForce(transform.forward * _speed);
    }

    private void NpcTarget()
    {
        Vector3 v1 = transform.position;
        Vector3 v2 = _target.transform.position;
        Vector3 v3 = v2 - v1;
        _rigidbody.AddForce(v3 * _speed );
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
        {
            other.gameObject.GetComponent<NpcController>().GiveDamage(_power);
        }
        if(!_rigidbody.isKinematic  && other.gameObject.GetComponent<NpcController>() )
            Destroy(gameObject);  
    }

    internal void SetUp(float bulletPower, float bulletSpeed)
    {
        _speed = bulletSpeed;
        _power = bulletPower;
    }

    private void OnDestroy()
    {
        if (_rigidbody.velocity.magnitude > 2 && false)
        {
            GameObject particles = Instantiate(_particles, transform.position, transform.rotation);
            Destroy(particles, 1);
        }
    }


    
}
