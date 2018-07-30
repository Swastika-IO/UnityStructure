using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class MyDBImpl : MyDatabase {

    private static MyDBImpl mInstance;
    private BinaryFormatter bf = new BinaryFormatter();
    private string mDataPath = "";

    public MyDBImpl()
    {
        mDataPath = Application.persistentDataPath;
    }

    public static MyDBImpl GetInstance()
    {
        if(mInstance == null)
        {
            mInstance = new MyDBImpl();
        }
        return mInstance;
    }

    public bool SaveObject(System.Object obj, string key)
    {
        try
        {
            string pathFile = MakePathFile(key);
            FileStream file = File.Create(pathFile);
            bf.Serialize(file, obj);
            file.Close();
            return true;
        }
        catch (Exception ex)
        {
            if (ex.Message != null)
            {
                Debug.Log(ex.Message);
            }
        }
        return false;
    }

    public T GetObject<T>(string key)
    {
        try
        {
            string pathFile = MakePathFile(key);
            //Check file is exists
            if (File.Exists(pathFile))
            {
                //Open this file to get data
                FileStream file = File.Open(pathFile, FileMode.Open);

                //Convert data to Serialize object
                T data = (T)bf.Deserialize(file);
                file.Close();
                return data;
            }
        }
        catch(Exception ex)
        {
            if (ex.Message != null) { 
                Debug.Log(ex.Message);
            }
        }
        return default(T);
    }

    public bool RemoveAllData()
    {
        RemoveObjectByKey(DBKey.USER_DATA_KEY);
        return true;
    }

    public bool RemoveObjectByKey(string key)
    {
        try
        {
            string pathFile = MakePathFile(key);
            if (File.Exists(pathFile))
            {
                File.Delete(pathFile);
                return true;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != null)
            {
                Debug.Log(ex.Message);
            }
        }
        return false;
    }

    /**
     * return a format path file
     **/
    private string MakePathFile(string key)
    {
        return mDataPath + "/" + key + ".dat";
    }
}
