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
    private int currentCameraView;
    private float delta;
    #endregion

    #region constants
    const int CURRENT_CAM_KEY = 10;
    const int NO_ACTIVE_CAM_KEY = 1;
    const string PLAYER_PREFS_KEY = "CAMERAS->CURRENT_CAMERA->PRIORITY";

    public float MIN_ZOOM { get; private set; }
    public float MAX_ZOOM { get; private set; }
    #endregion

    private void Start()
    {
        MIN_ZOOM = 5;
        MAX_ZOOM = 100;
        delta = _viewList[0].m_Lens.FieldOfView;
        // Cursor.lockState = CursorLockMode.Locked;
        OnCameraChanged.AddListener(CameraSwitchMainLogic);
        _cameraChangeHotKey = KeyCode.V;
    }

    private void CameraSwitchMainLogic( )
    {
       
        currentCameraView = PlayerPrefs.GetInt(PLAYER_PREFS_KEY);
        _viewList[currentCameraView].Priority = NO_ACTIVE_CAM_KEY;
        var lastIndex = _viewList.Count - 1;
        currentCameraView =  currentCameraView < lastIndex ? ++currentCameraView:0;
        _viewList[currentCameraView].Priority = CURRENT_CAM_KEY;
        delta = _viewList[currentCameraView].m_Lens.FieldOfView;
       PlayerPrefs.SetInt(PLAYER_PREFS_KEY, currentCameraView);

    }

    private void FixedUpdate()
    {
        delta += Input.GetAxis("Mouse ScrollWheel") * 60;
        delta = Mathf.Clamp(delta, MIN_ZOOM, MAX_ZOOM);
        _viewList[currentCameraView].m_Lens.FieldOfView = delta;  
    }
    private void Update()
    {
        if(Input.GetKeyDown(_cameraChangeHotKey))
            OnCameraChanged?.Invoke();
    }
}
