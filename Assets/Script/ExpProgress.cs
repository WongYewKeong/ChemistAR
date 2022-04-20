using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpProgress : MonoBehaviour
{
    public Text expProgressText;

    public string key;

    void Awake()
    {
        if (PlayerPrefs.GetInt(key) == 1)
        {
            expProgressText.text = "100%";
        }
    }
}
