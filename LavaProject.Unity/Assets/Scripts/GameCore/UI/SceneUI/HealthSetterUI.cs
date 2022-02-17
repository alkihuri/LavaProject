using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSetterUI : MonoBehaviour
{

    [SerializeField] GameObject _root;
    [SerializeField] TextMeshPro _text; 
    [SerializeField] ProgressBar _bar;

    GameObject _camera;

    private void Start()
    {
        _camera = Camera.main.gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _root.GetComponent<IHealthUI>().GetValue();
        _bar.BarValue = _root.GetComponent<IHealthUI>().GetFloatValue();
        transform.LookAt(_camera.transform.forward*100);
    }
}
