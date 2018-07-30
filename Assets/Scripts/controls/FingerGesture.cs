using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerGesture {
    public delegate void EventTouch(ActionType actionType, System.Object result);
    private event EventTouch OnTouched;

    private bool directionChosen;
    private Vector2 startPos;
    private Vector2 direction;
    private float _TimeTouched = 0;
    private LayerMask _FilterLayer;
    private bool _HasFilterMask = false;

    public void AddOnEventTouch(EventTouch eventHandler, LayerMask filterMask)
    {
        _FilterLayer = filterMask;
        this.OnTouched = eventHandler;
        _HasFilterMask = true;
    }

    public void AddOnEventTouch(EventTouch eventHandler)
    {
        _HasFilterMask = false;
        this.OnTouched = eventHandler;
    }

    // Update is called once per frame
    public void TrackingGesture() {
        // Track a single touch as a direction control.

        Vector3 positTouch = Vector3.zero;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            directionChosen = false;
        } else if (Input.GetMouseButtonUp(0))
        {
            positTouch = Input.mousePosition;
            directionChosen = true;
        }
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;
                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    positTouch = touch.position;
                    directionChosen = true;
                    break;
            }
        }
#endif
        if (directionChosen)
        {
            Ray ray = Camera.main.ScreenPointToRay(positTouch);
            RaycastHit hit;
            if (_HasFilterMask)
            {
                if (Physics.Raycast(ray, out hit, 100, _FilterLayer))
                {
                    SendCallbackEventTouch(hit.collider);
                }
            }
            else
            {
                if (Physics.Raycast(ray, out hit, 100))
                {
                    SendCallbackEventTouch(hit.collider);
                }
            }
            directionChosen = false;
        }
    }

    private void SendCallbackEventTouch(Object obj)
    {
        if (Time.time - _TimeTouched < 0.3f)
        {
            Debug.Log("ACTION_FINGER_DOUBLE_TOUCH");
            OnTouched(ActionType.ACTION_FINGER_DOUBLE_TOUCH, obj);
        }
        else
        {
            Debug.Log("ACTION_FINGER_TOUCH");
            OnTouched(ActionType.ACTION_FINGER_TOUCH, obj);
        }
        _TimeTouched = Time.time;
    }
}
