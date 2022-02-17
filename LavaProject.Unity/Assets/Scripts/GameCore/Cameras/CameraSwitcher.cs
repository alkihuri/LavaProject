using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;
using System;

public class CameraSwitcher : MonoBehaviour
{
    #region events
    public UnityEvent OnCameraChanged = new  UnityEvent ();
    #endregion

    #region fields
    [SerializeField] List<CinemachineVirtualCamera> _viewList; 
    [SerializeField] KeyCode _cameraChangeHotKey;
    #endregion

    #region constants
    const int CURRENT_CAM_KEY = 10;
    const int NO_ACTIVE_CAM_KEY = 1;
    const string PLAYER_PREFS_KEY = "CAMERAS->CURRENT_CAMERA->PRIORITY";
    #endregion

    private void Start()
    {
        OnCameraChanged.AddListener(CameraSwitchMainLogic);
        _cameraChangeHotKey = KeyCode.V;
    }

    private void CameraSwitchMainLogic( )
    {
        var currentCameraView = PlayerPrefs.GetInt(PLAYER_PREFS_KEY);
        _viewList[currentCameraView].Priority = NO_ACTIVE_CAM_KEY;
        var lastIndex = _viewList.Count - 1;
        currentCameraView =  currentCameraView < lastIndex ? ++currentCameraView:0;
        _viewList[currentCameraView].Priority = CURRENT_CAM_KEY;
        PlayerPrefs.SetInt(PLAYER_PREFS_KEY, currentCameraView);

    }

    private void Update()
    {
        if(Input.GetKeyDown(_cameraChangeHotKey))
            OnCameraChanged?.Invoke();
    }
}
