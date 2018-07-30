using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shake : MonoBehaviour {

    private float pos;
    private float posX;
    public int amp = 16;
    public float omega = 6;
    private float dX, dY;
    // Use this for initialization
    public Image mFish;
    private RectTransform mRect;
    void Start () {
        mRect = mFish.rectTransform;
        dX = mRect.anchoredPosition.x;
        dY = mRect.anchoredPosition.y;

    }
	
	// Update is called once per frame
	void Update () {
        pos = amp * Mathf.Sin(omega * Time.time);
        posX = amp * Mathf.Cos(omega * Time.time);
        mRect.anchoredPosition3D= new Vector3(dX+posX, dY+ pos,0);
    }
}
