using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSetterUI : MonoBehaviour
{

    [SerializeField] GameObject _root;
    [SerializeField] TextMeshPro _text;
     
    // Update is called once per frame
    void Update()
    {
        _text.text =  _root.GetComponent<IHealthUI>().GetValue();
    }
}
