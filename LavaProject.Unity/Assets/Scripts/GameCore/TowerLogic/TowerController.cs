using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerController : MonoBehaviour, IHealthUI
{
    [SerializeField,Range(0,100)] float _hp;

    public UnityEvent<int> OnHpChanged = new UnityEvent<int>(); 

    // тут просто говнокод если хотите чекнуть 
    public void TakeDamage(int value)
    {
        var newHp = Mathf.Clamp(_hp - value, 0, 100);
    }

    private void OnCollisionEnter(Collision collision)
    {
         OnHpChanged.Invoke(1);
    }

    public Vector3 FirePoint 
    { 
        get 
            { 
                return transform.GetChild(0).transform.position;  
            } 
    }

    private void Start()
    {
        OnHpChanged.AddListener(TakeDamage);
    }

    public string GetValue()
    {
        return _hp.ToString("#.");
    }

    public float GetFloatValue()
    {
        throw new System.NotImplementedException();
    }
}
