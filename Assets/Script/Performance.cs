using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Performance : MonoBehaviour
{
    private static bool created = false;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
    }

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

        }
    }


}
