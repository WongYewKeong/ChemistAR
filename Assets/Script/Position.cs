using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public GameObject groundPlane;
    public GameObject GO;

    // Update is called once per frame
    public void Placed()
    {
        GO.transform.position=new Vector3(gameObject.transform.position.x,groundPlane.transform.position.y,0.35f);
        
       // RotateTowardsCamera(GO);
    }

    void RotateTowardsCamera(GameObject augmentation)
    {
        var lookAtPosition =  augmentation.transform.position ;
        lookAtPosition.y = 0;
        var rotation = Quaternion.LookRotation(lookAtPosition);
        augmentation.transform.rotation = rotation;
    }

}
