using Assets.Scripts.data;
using Assets.Scripts.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.ui.splashscreen
{
    class SplashPresenter<V> : MyPresenterImpl<V> where V : ISplashView
    {
        public SplashPresenter(SchedulerProvider schedulerProvider, IDataManager dataManager)
        : base(schedulerProvider, dataManager)
        {
        }

        public void GetProvince()
        {
            Add(_DataManager.GetProvince().CatchIgnore((WWWErrorException ex) => { HandleApiError(ex); }).
                Subscribe((string data) => { OnGetProvinces(data); }));
        }

        public void DoLogin()
        {
            PostLogin postLogin = new PostLogin
            {
                Name="intelligent2610",
                Password="9900203"
            };
            Add(_DataManager.Login(postLogin).CatchIgnore((WWWErrorException ex) => { HandleApiError(ex); }).
                Subscribe((string data) => { OnResponseLogin(data); }));
        }

        private void OnResponseLogin(string data)
        {
            Debug.Log(data);
        }

        private void OnGetProvinces(string data)
        {
            ResponseData<List<ProvinceObject>> objResponse = JsonUtility.FromJson<ResponseData<List<ProvinceObject>>>(data);
            if (objResponse.IsSuccess)
            {
                _DataManager.SaveProvinces(objResponse.data);
            }
            else
            {
                GetBaseView().OnError(objResponse.message);
            }
            GetBaseView().HideLoading();
        }


    }
}
