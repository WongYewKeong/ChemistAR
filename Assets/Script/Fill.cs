using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fill : MonoBehaviour
{
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend=GetComponent<Renderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fillAcid(){
        rend.material.SetFloat("Fill",0.6f);
    }
}
