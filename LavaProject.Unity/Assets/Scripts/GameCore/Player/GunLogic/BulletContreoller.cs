using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletContreoller : MonoBehaviour
{

    GameObject _target;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] GameObject _particles;
    [SerializeField,Range(0,100)] float _timeToDie = 5f;
    private float _speed;
    private float _power;
    [SerializeField] AnimationCurve _sizeOverLife;
    private float distace;

    public UnityEvent OnExplosion;


    private void Awake()
    {
        OnExplosion.AddListener(AudioManager.Instance.PlayExplosion);
    }
    private void Start()
    {
        GetComponent<TrailRenderer>().enabled = false;
        _timeToDie = 1;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false; 
       
    }

    private void FixedUpdate()
    {

        if(!_rigidbody.isKinematic)
        {
            if(_target != null)
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
        Vector3 direction = _target.transform.position - transform.position; ;
        _rigidbody.AddForce(direction * _speed );
    }


    public  void SetDestination(GameObject position)
    {
        GetComponent<TrailRenderer>().enabled = true;
        _rigidbody.isKinematic = false; 
        _target = position;
        _rigidbody.AddForce(transform.up * 5, ForceMode.Impulse);
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
        OnExplosion.Invoke();
        if (_rigidbody.velocity.magnitude > 2 )
        {
            GameObject particles = Instantiate(_particles, transform.position, transform.rotation);
            Destroy(particles, 1);
        }
    }


    
}
