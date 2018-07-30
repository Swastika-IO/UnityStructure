using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBasic : MonoBehaviour {
    public ActionType _ActionType;

    // Use this for initialization
    void Start () {
		
	}

    public bool CheckTouch(ActionType actionType)
    {
        if(actionType == _ActionType)
        {
            ProccessAction();
            return true;
        }
        return false;
    }

    public virtual void ProccessAction()
    {
        //Xữ lý action
        Debug.Log("ProccessAction p");
    }
	
}
