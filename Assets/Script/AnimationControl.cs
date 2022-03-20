using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public GameObject gameObjectHide,gameObjectActive;
    public void hideObject(){
        gameObjectHide.SetActive(false);
    }
    public void activeObject(){
        gameObjectActive.SetActive(true);
    }

}
