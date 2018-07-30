using System;
using System.Collections;
using System.Collections.Generic;

interface MyDatabase {
    /**
     * The method below using to get a Serialize object by key
     */
    T GetObject<T>(string key);

    /**
     * The method below using to save a Serialize object by key
     */
    bool SaveObject(Object obj, string key);

    /**
     * The method below using to remove all data
     */
    bool RemoveAllData();

    /**
     * The method below using to remove data by key
     */
    bool RemoveObjectByKey(string key);
}
