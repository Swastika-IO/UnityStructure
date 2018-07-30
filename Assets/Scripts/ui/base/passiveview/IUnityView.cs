using Assets.Scripts.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnityView  {

    void ShowLoading();

    void HideLoading();

    void OnError(string message);

    void ShowMessage(string message, MessageType messageType, AlertType alertType);

    bool IsNetworkConnected();

    void OnTokenExpired();

    void OnConnectToServerError();

    void OnNoInternetConnection();

    void OnDismissNotifyConnectionDialog(string status);
}
