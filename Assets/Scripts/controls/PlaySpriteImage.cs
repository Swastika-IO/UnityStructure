using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySpriteImage : MonoBehaviour {
    public Sprite[] listSprites;
    private Image mImage;
    private int index = 0;
    public float TimeDelay = 0.5f;
	// Use this for initialization
	void Start () {
        mImage = GetComponent<Image>();
        StartCoroutine(ChangeImage());
    }
	
	private IEnumerator ChangeImage()
    {
        mImage.sprite = listSprites[index];
        index++;
        if (index == listSprites.Length)
        {
            index = 0;
        }
        yield return new WaitForSeconds(TimeDelay);
        StartCoroutine(ChangeImage());
    }
}
