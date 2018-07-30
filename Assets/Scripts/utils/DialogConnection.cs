using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.utils
{
    class DialogConnection : MonoBehaviour
    {
        public static DialogConnection instance;

        public delegate void OnReloadConnection(string status);
        private event OnReloadConnection DLOnReload;
        public Text _TextMessage;
        public GameObject _GroupConnection;

        private void Awake()
        {
            instance = this;
        }

        public void HideDlgConnection()
        {
            _GroupConnection.SetActive(false);
            DLOnReload("");
        }

        public void ShowDlgConnection(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                _TextMessage.text = message;
            }
            _GroupConnection.SetActive(true);
        }

        public void SetCallback(OnReloadConnection onReload)
        {
            this.DLOnReload = onReload;
        }

    }
}
