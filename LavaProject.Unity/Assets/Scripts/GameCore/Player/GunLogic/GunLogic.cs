using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunLogic : MonoBehaviour
{
    [SerializeField] GameObject _bullet;

    UnityEvent OnShot = new UnityEvent();

    [SerializeField] GameObject _enemy;

    [SerializeField] KeyCode _attacKey;
    [SerializeField] GameObject _bulletPrefab;

    private void Start()
    {
        _bullet = transform.GetChild(0).gameObject;
        OnShot.AddListener(Shot);
        _attacKey = KeyCode.Space;
    }

    private void Shot()
    {
        _bullet.transform.SetParent(null);
        _bullet.AddComponent<Rigidbody>();
        _bullet.GetComponent<BulletContreoller>().SetDestination(_enemy);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_attacKey))
            OnShot.Invoke();
        if(!(transform.childCount > 0))
        {
            GameObject newBullet = Instantiate(_bulletPrefab, transform);
            newBullet.transform.localPosition = Vector3.zero;
            newBullet.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f); //shit
            _bullet = newBullet;
        }
    }

    private void FixedUpdate()
    {
        if (_enemy == null)
            _enemy = GameObject.FindObjectOfType<NpcController>().gameObject;
    }
}