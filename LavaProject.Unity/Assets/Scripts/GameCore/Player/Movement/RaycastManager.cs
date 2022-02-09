using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    Camera _camera;
    Vector3 _destinationPoint;
    Ray _worldPosMousePoint;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }
    public Vector3 GetDestinationPoint()
    {
        transform.LookAt(_destinationPoint);
        return _destinationPoint;
    }


    // Update is called once per frame
    void Update()
    {
        _worldPosMousePoint = _camera.ScreenPointToRay(Input.mousePosition);
        
        RaycastFeature();
    }

    private void RaycastFeature()
    {
        RaycastHit objectOnHitLine;
        var direction = _worldPosMousePoint;
        if (Physics.Raycast(_worldPosMousePoint, out objectOnHitLine))
        {
            _destinationPoint = objectOnHitLine.point;
        }
    }

     
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_destinationPoint, 0.2f); 
    }
}
