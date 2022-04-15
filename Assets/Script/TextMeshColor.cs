using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshColor : MonoBehaviour
{
   public TextMesh textMesh;

    public void TextColor()
    {
        textMesh.color = Color.yellow;
    }
}
