using Assets.Scripts.connection;
using Assets.Scripts.data.connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;

namespace Assets.Scripts.data
{
    public class DataManager : IDataManager, IApiHelper
    {
        private static DataManager _Instance;
        private PlayerData _PlayerData;
        private ApiHelper _ApiHelper;
        private List<ProvinceObject> _ListProvince;

        public static DataManager getInstance()
        {
            if (_Instance == null)
            {
                _Instance = new DataManager();
            }
            return _Instance;
        }

        private DataManager()
        {
            _PlayerData = PlayerData.GetCurrentObject();
            _ListProvince = MyDBImpl.GetInstance().GetObject<List<ProvinceObject>>(DBKey.PROVINCE_DATA_KEY);
            _ApiHelper = ApiHelper.getInstance(MyHeader.GetIntance());
        }


        public void SavePlayerData(PlayerData playerData)
        {
            _PlayerData = playerData;
            PlayerData.SetCurrentObject(_PlayerData);
        }

        public PlayerData GetPlayerData()
        {
            return _PlayerData;
        }

        public IObservable<string> GetProvince()
        {
            return _ApiHelper.GetProvince();
        }

        public IObservable<string> GetCustomerList()
        {
            return _ApiHelper.GetCustomerList();
        }

        public void SaveProvinces(List<ProvinceObject> list)
        {
            _ListProvince = list;
            MyDBImpl.GetInstance().SaveObject(list, DBKey.PROVINCE_DATA_KEY);
        }

        public List<ProvinceObject> GetProvincesData()
        {
            return _ListProvince;
        }

        public IObservable<string> Login(PostLogin postLogin)
        {
            return _ApiHelper.Login(postLogin);
        }
    }
}
