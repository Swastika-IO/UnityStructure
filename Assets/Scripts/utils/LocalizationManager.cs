using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager instance;

    private Dictionary<LocalizedKey, string> localizedText;
    private bool isReady = false;
    private bool isProcessing = false;
    private string missingTextString = "Localized text not found";

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadLocalizedText(string fileName)
    {
        if (isProcessing)
        {
            return;
        }

        isProcessing = true;
        localizedText = new Dictionary<LocalizedKey, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        StartCoroutine(InitDictionaryLang(filePath));
    }

    private IEnumerator InitDictionaryLang(string filePath)
    {
        string dataAsJson;

        #if UNITY_EDITOR || !UNITY_ANDROID
            dataAsJson = System.IO.File.ReadAllText(filePath);
            yield return new WaitForSeconds(0.2f);
        #else
            WWW www = new WWW(filePath);
            yield return www;
            dataAsJson = www.text;
        #endif

        //if (File.Exists(filePath))
        //{
        LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

        for (int i = 0; i < loadedData.items.Length; i++)
        {
            localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
        }

        #if UNITY_EDITOR
            if (Util.IS_DEBUG)
            {
                Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries");
            }
        #endif

        //}
        //else
        //{
        //    Debug.LogError("Cannot find file!");
        //}

        isReady = true;
    }

    public string GetLocalizedValue(LocalizedKey key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }

        return result;

    }

    public bool GetIsReady()
    {
        return isReady;
    }

}