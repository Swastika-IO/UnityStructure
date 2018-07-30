using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseMonoBehaviour : MonoBehaviour, IUnityView
{

	// Use this for initialization
	public virtual void Awake() {
        //if (!LocalizationManager.instance.GetIsReady())
        //{
        //    SceneManager.LoadScene("SplashScene");
        //}
    }

    public virtual void Start()
    {
        DialogConnection.instance.SetCallback(OnDismissNotifyConnectionDialog);
    }

    public void HideLoading()
    {
        LoadingUIUtil.instance.HideLoading();
    }

    public bool IsNetworkConnected()
    {
        throw new System.NotImplementedException();
    }

    public void OnConnectToServerError()
    {
        if (DialogConnection.instance != null)
        {
            DialogConnection.instance.ShowDlgConnection("OnConnectToServerError");
        }
    }

    public virtual void OnDismissNotifyConnectionDialog(string status)
    {
        //not thing to do
    }

    public void OnError(string message)
    {
        if (message != null)
        {
            ShowMessage(message, MessageType.ERROR, AlertType.TOAST);
        }
    }

    public void OnNoInternetConnection()
    {
        if (DialogConnection.instance != null)
        {
            DialogConnection.instance.ShowDlgConnection("OnNoInternetConnection");
        }
    }

    public void OnTokenExpired()
    {
        throw new System.NotImplementedException();
    }

    public void ShowLoading()
    {
        LoadingUIUtil.instance.ShowLoading();
    }

    public void ShowMessage(string message, MessageType messageType, AlertType alertType)
    {
        if (message != null)
        {
            switch (alertType)
            {
                case AlertType.INFO_DIALOG:
                    LoadingUIUtil.instance.ShowMessage(message);
                    break;
                case AlertType.TOAST:
                    LoadingUIUtil.instance.ShowMessage(message);
                    break;
                case AlertType.SNACKBAR:
                    break;
            }
        }
    }
}
