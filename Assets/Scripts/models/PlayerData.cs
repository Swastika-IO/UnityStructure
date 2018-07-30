using System;

[Serializable]
public class PlayerData {

    private static PlayerData currentObject;

    public string PlayerName { get; set; }

    public static PlayerData GetCurrentObject()
    {
        if (currentObject == null)
        {
            currentObject = MyDBImpl.GetInstance().GetObject<PlayerData>(DBKey.USER_DATA_KEY);
        }
        return currentObject;
    }

    public static void SetCurrentObject(PlayerData data)
    {
        MyDBImpl.GetInstance().SaveObject(data, DBKey.USER_DATA_KEY);
    }
}
