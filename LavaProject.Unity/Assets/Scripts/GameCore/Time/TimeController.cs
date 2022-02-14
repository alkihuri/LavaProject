using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    bool iSspacePressed;
     
    void Update()
    {
        iSspacePressed = Input.GetKey(KeyCode.Space);
        Time.timeScale = iSspacePressed ? 0.7f : 1; 
    }
     
     
}
