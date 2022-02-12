using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class GunLogic : MonoBehaviour
{
    [SerializeField] GameObject _bullet;

    UnityEvent OnShot = new UnityEvent();

    [SerializeField] List<GameObject> _enemyList = new List<GameObject>();

    [SerializeField] KeyCode _attacKey;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] PlayerAnimController _playerAnimController;

    private void Start()
    {
        _bullet = transform.GetChild(0).gameObject;
        OnShot.AddListener(Shot);
        _attacKey = KeyCode.Space;
    }

    private void Shot()
    {
        StartCoroutine(DelayShot(0.5f));
    }

    IEnumerator DelayShot(float sec)
    {

        _enemyList = _enemyList.Where(enemy => enemy != null).ToList();
        _playerAnimController.PlayAttack();
        yield return new WaitForSeconds(sec);
        BulletReleaseAndShot();
    }

    private void BulletReleaseAndShot()
    {
        _bullet.transform.SetParent(null);
        _bullet.AddComponent<Rigidbody>(); 

        GameObject enemy = _enemyList
                        .Select(enemy => enemy.transform)
                            .OrderBy(enemyTransform 
                                    => Vector3.Distance(transform.position, enemyTransform.position))
                                            .ToList()[0].gameObject;
        _bullet.GetComponent<BulletContreoller>().SetDestination(enemy);



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_attacKey))
            OnShot.Invoke();
        if(!(transform.childCount > 0))
        {
            NewBulletSpawn();
        }
    }

    private void NewBulletSpawn()
    {
        GameObject newBullet = Instantiate(_bulletPrefab, transform);
        newBullet.transform.localPosition = Vector3.zero;
        newBullet.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f); //shit
        _bullet = newBullet;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject enteredObject = other.transform.gameObject;
        if (enteredObject.GetComponent<NpcController>())
        {
            if(!_enemyList.Contains(enteredObject))
                    _enemyList.Add(enteredObject);
        }

        if (_enemyList.Count > 0) 
            GetComponent<GunLightController>().Switch(Color.red);
    }
    private void OnTriggerExit(Collider other)
    {
       
        GameObject enteredObject = other.transform.gameObject;
        if (enteredObject.GetComponent<NpcController>())
        {
            _enemyList.Remove(enteredObject);
        }
        if (_enemyList.Count<1)
        {
            _enemyList.Clear();
            GetComponent<GunLightController>().Switch(Color.green);
        }
         
    }
}
