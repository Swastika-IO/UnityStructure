using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSoundUI : MonoBehaviour {
    public static ManageSoundUI _Intance;

    public AudioClip Sound_ButtonPress;

    void Awake()
    {
        _Intance = this;
    }
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	public void ButtonClick()
    {
        AudioSource.PlayClipAtPoint(Sound_ButtonPress, Vector3.zero);
    }
}
