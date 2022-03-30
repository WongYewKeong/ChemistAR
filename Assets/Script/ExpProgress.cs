using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpProgress : MonoBehaviour
{
    public Text expProgressText;

    public string key;
    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt(key) == 1)
        {
            expProgressText.text = "100%";
        }
    }
}
