using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchRotateCam : MonoBehaviour {

    public float smoothFactorGoBack = 2.5f;
    public float smoothFactorDrag = 2.5f;

    public float sensitivityX = 2;
    public float sensitivityY = 2;

    private bool isLockRotate = false;

    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalRotation;

    Transform _Transform;

    public Text mTextDebug;
    // Use this for initialization
    void Start ()
    {
        _Transform = transform;
        originalRotation = _Transform.localRotation;
    }

    // Update is called once per frame
    void Update () {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0) && !isLockRotate)
        {
            ////Move finger by screen
            if (Input.GetMouseButton(0))
#else
        if (Input.touchCount == 1 && !isLockRotate)
        {
            ////Move finger by screen
            if (Input.GetTouch(0).phase == TouchPhase.Moved )
#endif
            {
                //float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
                //rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                //transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);


                rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);

                _Transform.localRotation = Quaternion.Lerp(_Transform.localRotation, originalRotation * xQuaternion * yQuaternion, Time.deltaTime * smoothFactorDrag);
            }
        }
        else
        {
            _Transform.localRotation = Quaternion.Lerp(_Transform.localRotation, Quaternion.identity, Time.deltaTime * smoothFactorGoBack);
            rotationY = -_Transform.localEulerAngles.x;
            rotationX = _Transform.localEulerAngles.y;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
         angle += 360F;
        if (angle > 360F)
         angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

    public void LockRotate() {
        isLockRotate = true;
    }

    public void UnLockRotate()
    {
        isLockRotate = false;
    }
}
