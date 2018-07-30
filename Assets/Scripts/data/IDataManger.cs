using Assets.Scripts.data.connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.data
{
    public interface IDataManager : IApiHelper
    {
        void SavePlayerData(PlayerData playerData);
        PlayerData GetPlayerData();
        void SaveProvinces(List<ProvinceObject> list);
        List<ProvinceObject> GetProvincesData();
    }
}
