using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class GunLogic : MonoBehaviour
{
    private const float shootDelay = 0.5f;
    [SerializeField] GameObject _bullet; 
    UnityEvent OnShot = new UnityEvent(); 
    [SerializeField] List<GameObject> _enemyList = new List<GameObject>(); 
    [SerializeField] KeyCode _attacKey;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] PlayerAnimController _playerAnimController;
    [SerializeField, Range(0, 100)] float _bulletPower; 
    [SerializeField, Range(0, 100)] float _bulletSpeed;
    private GameObject targetedEnemy;

    public void SetGunSettings(float power, float speed)
    {
        _bulletPower = power;
        _bulletSpeed = speed;
    }

    private void Start()
    {
        _bullet = transform.GetChild(0).gameObject;
        OnShot.AddListener(Shot);
        _attacKey = KeyCode.Space;
        FindNewEnemy();
    }

    private void Shot()
    {
        StartCoroutine(DelayShot(shootDelay));
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
       if(_enemyList.Count>0)
        {
            _bullet.transform.SetParent(null); 
            FindNewEnemy(); 
            _bullet.GetComponent<BulletContreoller>().SetUp(_bulletPower, _bulletSpeed);
            _bullet.GetComponent<BulletContreoller>().SetDestination(targetedEnemy);
        }

    }

    private void FindNewEnemy()
    {
        targetedEnemy = _enemyList
                                    .Select(enemy => enemy.transform)
                                        .OrderBy(enemyTransform
                                                => Vector3.Distance(transform.position, enemyTransform.position))
                                                        .ToList()[0].gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_attacKey))
        {
            OnShot.Invoke();
        }
        if(!(transform.childCount > 0))
        {
            NewBulletSpawn();
        }
    }

    private void NewBulletSpawn()
    {
        GameObject newBullet = Instantiate(_bulletPrefab, transform);
        newBullet.transform.localPosition = Vector3.zero;
        newBullet.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f); //shit
        _bullet = newBullet;
    }

    private void OnTriggerEnter(Collider other)
    {
        LightFeature(other);

    }

    private void LightFeature(Collider other)
    {
        GameObject enteredObject = other.transform.gameObject;
        if (enteredObject.GetComponent<NpcController>())
        {
            if (!_enemyList.Contains(enteredObject))
                _enemyList.Add(enteredObject);
        }
        if (_enemyList.Count > 0)
            GetComponent<GunLightController>().Switch(Color.red);
        else
        {
            _enemyList.Clear();
            GetComponent<GunLightController>().Switch(Color.green);
        }
    }

    private void OnTriggerExit(Collider other)
    {
       
        GameObject enteredObject = other.transform.gameObject;
        if (enteredObject.GetComponent<NpcController>())
        {
            _enemyList.Remove(enteredObject);
        } 
         
    }
}
