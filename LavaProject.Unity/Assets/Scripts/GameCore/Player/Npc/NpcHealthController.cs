using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcHealthController : MonoBehaviour
{
    public Text _healthPointsTextField;
    public float _health;
    // Start is called before the first frame update
    void Start()
    { 
        _health = 100;
    }
    public void TakeDamage(float gunDamageRate)
    {
        _health = _health - gunDamageRate; 
        if (_health < 0)
        {
            GetComponentInChildren<Animator>().enabled = false;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        _healthPointsTextField.text = _health.ToString() + "/" + 100;
    }
}
