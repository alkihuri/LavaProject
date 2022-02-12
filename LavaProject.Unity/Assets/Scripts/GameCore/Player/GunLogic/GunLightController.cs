using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLightController : MonoBehaviour
{

    [SerializeField] Light _light;

    [SerializeField] Color _color;
    public void Switch(Color color)
    {
        StartCoroutine(SwitchTo(color));
    }

    private void Update()
    {
        _color = _light.color;
    }
    IEnumerator SwitchTo(Color color)
    {
        Color current = _light.color;
        for(float i =0;i<1;i+=0.1f)
        {
            _light.color = Color.Lerp(current, color, i);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
