using Assets.Scripts.connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;

namespace Assets.Scripts.data.connection
{
    class ApiHelper : IApiHelper
    {
        private static ApiHelper _Instance;
        private  MyHeader _Header;

        public static ApiHelper getInstance(MyHeader myHeader)
        {
            if (_Instance == null)
            {
                _Instance = new ApiHelper(myHeader);
            }
            return _Instance;
        }

        public IObservable<string> GetProvince()
        {
            return ObservableWWW.Get(MyApi.API_GET_PROVINCE, _Header.GetPublicHeader());
        }

        public IObservable<string> GetCustomerList()
        {
            return ObservableWWW.Post("API", RequestDataWWW.GetParamWaitingCustomer(), _Header.GetPublicHeader());
        }

        public IObservable<string> Login(PostLogin postLogin)
        {
            return ObservableWWW.Post(MyApi.API_POST_LOGIN, RequestDataWWW.GetLoginForm(postLogin), _Header.GetPublicHeader());
        }

        public ApiHelper(MyHeader myHeader)
        {
            _Header = myHeader;
        }

    }
}
