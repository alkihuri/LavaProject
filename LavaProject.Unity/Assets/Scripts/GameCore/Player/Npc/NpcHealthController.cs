using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NpcHealthController : MonoBehaviour, IHealthUI
{ 
    public float _health; 
    [SerializeField] public UnityEvent OnDie = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        
       _health = 100;
        OnDie.AddListener(Die);
    }
    public void TakeDamage(float gunDamageRate)
    {
        var newHP = _health - gunDamageRate;
        _health = Mathf.Clamp(newHP, 0, 100);
        if (_health <= 0)  OnDie.Invoke();
      
    }
     
    public void Die()
    { 
        GetComponentInChildren<Animator>().enabled = false;
        Destroy(GetComponent<NpcController>());
        Destroy(GetComponent<NpcStateMachine>());
        Destroy(gameObject,5);
    }

    public string GetValue()
    {
        return _health.ToString();
    }
}
