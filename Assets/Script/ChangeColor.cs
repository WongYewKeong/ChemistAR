using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Renderer rend;
    
    Color newColor =new Color(0.06f,0.06f,0.05f,0f);
    Color colorMnO3=new Color(0.38f,0.28f,0.16f);
    
    public void changeColor()
    {
        rend.material.SetColor("SideColor",newColor);
        rend.material.SetColor("TopColor",newColor);

    }

    public void changeColorMno3()
    {
        rend.material.SetColor("SideColor",colorMnO3);
        rend.material.SetColor("TopColor",colorMnO3);

    }
}
