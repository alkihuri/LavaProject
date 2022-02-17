using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour,IHealthUI
{

    [SerializeField,Range(0,100)] float _health;
    [SerializeField] bool _immortalMode;
    [SerializeField] GameObject _particles;
    // Start is called before the first frame update
    void Start()
    {
        _health = 100;
        _immortalMode = false;
    }
     

    public void TakeDamage(float damageValue)
    {
        if (!_immortalMode)
        {
            var newValue = _health - damageValue;
            _health = Mathf.Clamp(newValue, 0, 100);
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        } 
    }

    private void OnDestroy()
    {
        var effect = Instantiate(_particles, transform.position, transform.rotation);
        Destroy(effect, 2);
    }

    public string GetValue()
    {
        return _health.ToString("#.");
    }

    public float GetFloatValue()
    {
        return _health;
    }
}
