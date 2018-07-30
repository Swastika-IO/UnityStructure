using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour {

    public Transform mTargetLook;
    public float SmoothFactor = 1.5f;
    Transform _Transform;
    // Use this for initialization
    void Start () {
        _Transform = transform;
    }
	
	// Update is called once per frame
	void Update () {
        Quaternion newRotation = Quaternion.LookRotation(mTargetLook.position - _Transform.position);
        _Transform.rotation = Quaternion.Slerp(_Transform.rotation, newRotation, Time.deltaTime * SmoothFactor);
	}
}
