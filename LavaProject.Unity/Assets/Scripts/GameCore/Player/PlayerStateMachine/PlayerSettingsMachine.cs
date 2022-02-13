using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSettingsMachine : MonoBehaviour
{
    float   _characterSpeed;
    float   _characterBulletPower;
    float   _characterBulletSpeed;

    [SerializeField] NavMeshAgent _player;
    [SerializeField] GunLogic _gun; 
    void HandleDataFromPlayerPrefs()
    {
        _characterSpeed         = PlayerPrefs.GetFloat(new DataSettingHandler().CHARACTER_SPEED_KEY);
        _characterBulletPower   = PlayerPrefs.GetFloat(new DataSettingHandler().CHARACTER_BULLET_POWER_KEY);
        _characterBulletSpeed   = PlayerPrefs.GetFloat(new DataSettingHandler().CHARACTER_BULLET_SPEED_KEY);
    }

    void ApplyStateSettings()
    {
        _player.speed = _characterSpeed;
        _gun.SetGunSettings(_characterBulletPower, _characterBulletSpeed);
    }
    // Start is called before the first frame update
    
    public void SetUp()
    {
        HandleDataFromPlayerPrefs();
        ApplyStateSettings();
    }
    private void Awake()
    {
        _player = GetComponent<NavMeshAgent>();
        _gun = GetComponentInChildren<GunLogic>();
    }
}
