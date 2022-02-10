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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_attacKey))
            OnShot.Invoke();
    }
}
