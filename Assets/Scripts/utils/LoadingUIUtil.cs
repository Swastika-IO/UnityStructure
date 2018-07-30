using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUIUtil : MonoBehaviour {

    public static LoadingUIUtil instance;

    public Text mTextMessage;
    public GameObject mGroupLoading;
    public GameObject mGroupMessage;

    //Init DialogLoading contrl
    void Awake()
    {
        instance = this;
    }

    public void HideMessage()
    {
        mGroupMessage.SetActive(false);
    }

    //Put message into UI and show GroupMessage
    public void ShowMessage(string strMsg)
    {
        mTextMessage.text = strMsg;
        mGroupMessage.SetActive(true);
    }

    public void ShowLoading()
    {
        mGroupLoading.SetActive(true);
    }

    public void HideLoading()
    {
        mGroupLoading.SetActive(false);
    }
}
