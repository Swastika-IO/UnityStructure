using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour {
    public Transform mGroupCharacter;
    public float mSpeed = 0.5f;
    public Transform mTarget;
    private bool isActived = true;

	// Use this for initialization
	void Start () {
		
	}

    public void SetCharacterActive(bool flag)
    {
        if (isActived != flag)
        {
            isActived = flag;
            mGroupCharacter.position = mTarget.position;
            mGroupCharacter.rotation = mTarget.rotation;
            mGroupCharacter.gameObject.SetActive(isActived);
        }
    }
	
	// Update is called once per frame
	void Update () {
        mGroupCharacter.position = Vector3.Slerp(mGroupCharacter.position, mTarget.position, mSpeed * Time.deltaTime);
        mGroupCharacter.rotation = Quaternion.Slerp(mGroupCharacter.rotation, mTarget.rotation, mSpeed * Time.deltaTime);
    }
}
