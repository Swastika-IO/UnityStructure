using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchMoveTool : MonoBehaviour {

    public Animator _AnimTool;
    public Image _ToolNav;
    private bool isExpand = false;
	// Use this for initialization
	void Start () {
    }
	

    public void OnToolClicked ()
    {
        isExpand = !isExpand;
        _AnimTool.SetBool("NavExpand", isExpand);
    }
}
