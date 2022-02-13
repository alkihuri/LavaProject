using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class DataSettingHandler : MonoBehaviour
{
    [SerializeField] PlayerState _stateToSet;
    public UnityEvent OnStateChange             = new UnityEvent();
    public   string CHARACTER_SPEED_KEY         = "CHARACTER->SPEED";
    public   string CHARACTER_BULLET_POWER_KEY  = "CHARACTER->BULLET->POWER";
    public   string CHARACTER_BULLET_SPEED_KEY  = "CHARACTER->BULLET->SPEED";
    public DataSettingHandler _instance { get { return new DataSettingHandler(); } }

    private void Start()
    {
        OnStateChange.AddListener(SaveToPlayerPrefs);
        OnStateChange?.Invoke();
    }

    public void SaveToPlayerPrefs()
    {
        PlayerPrefs.SetFloat(CHARACTER_SPEED_KEY,    _stateToSet.CHARACTER_SPEED);
        PlayerPrefs.SetFloat(CHARACTER_BULLET_POWER_KEY,      _stateToSet.BULLET_POWER);
        PlayerPrefs.SetFloat(CHARACTER_BULLET_SPEED_KEY,      _stateToSet.SHOOTING_SPEED);
    }
     
}
