using System;
using UnityEngine;

namespace Inputs.Characters.Scripts
{
    public class GameUXController : MonoBehaviour
    {
        [SerializeField]
        SaidController _saidController;

        private Vector2 startTouchPosition;

        [SerializeField]
        private float touchThreshold = 20f;

        private void Start()
        {
            _saidController = GetComponent<SaidController>();
        }

        private void Update()
        {
            #if !UNITY_EDITOR
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
                WorkWithTouches();
            #endif
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _saidController.OnRightMove();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _saidController.OnLeftMove();
            }
        }
#if !UNITY_EDITOR
        
        void WorkWithTouches()
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;
                case TouchPhase.Ended:
                {
                    if (Mathf.Abs(touch.position.x - startTouchPosition.x) > touchThreshold)
                    {
                        if ((touch.position.x - startTouchPosition.x) > 0)
                        {
                            _saidController.OnRightMove();
                        }
                        else
                        {
                            _saidController.OnLeftMove();
                        }
                    }

                    break;
                }
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
#endif

    }
}