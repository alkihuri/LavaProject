using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class NpcAiSonar : MonoBehaviour
{
    [SerializeField,Range(0, 100)] float _radius;
    [SerializeField] GameObject _sonar;
    [SerializeField] bool _isActive;
    [SerializeField] NpcController _npcController;
    [SerializeField] Vector3 _attentionPoint;

    void Start()
    {
        _npcController = GetComponent<NpcController>();
        _radius = 50;
        _isActive = true;
        StartCoroutine(SonarFeature());
    }

    

    IEnumerator  SonarFeature()
    {
       while(_isActive)
       {  
           for(float xAngle = 0;xAngle<2;xAngle+=0.5f)
            {
                for (int yAngle = 0; yAngle < 360; yAngle += 10)
                {
                    _sonar.transform.rotation = Quaternion.Euler( 0,yAngle, 0);
                    _sonar.transform.localPosition =  new Vector3(0, xAngle, 0);
                    DebugRays();
                    RaycastFeature();
                }

                yield return new WaitForSeconds(1 /2);
            }
        }
    }

    private void RaycastFeature()
    {
        Vector3 startVector = _sonar.transform.GetChild(0).transform.position;
        Vector3 directionVector = _sonar.transform.GetChild(0).transform.forward;
        RaycastHit _objectOnVisionLine;
        if (Physics.Raycast(startVector, directionVector, out _objectOnVisionLine, _radius))
        {

            if (_objectOnVisionLine.transform.gameObject.GetComponent<NpcController>())
                return;

            _attentionPoint = _objectOnVisionLine.point;
            transform.LookAt(_attentionPoint); 
            _npcController.SetDestination(_attentionPoint); 
           
        } 
    }

    private void DebugRays()
    {
        Vector3 start = _sonar.transform.position;
        Vector3 direction = _sonar.transform.GetChild(0).transform.position;
        Debug.DrawLine(start, direction, Color.yellow, 0.49f);
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_attentionPoint, 0.5f);
    }
}