using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    public LocalizedKey key;
    // Use this for initialization
    void Start()
    {
        Text text = GetComponent<Text>();
        text.text = LocalizationManager.instance.GetLocalizedValue(key);
    }

}