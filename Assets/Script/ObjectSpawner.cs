using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    private PlacementIndicator placementIndicator;
    private bool hasSpawned=false;


    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();

    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if(hasSpawned==false){
            GameObject obj = Instantiate(objectToSpawn, 
                placementIndicator.transform.position, placementIndicator.transform.rotation);
                hasSpawned=true;
            }
        }
        
    } 

    public void Activate() {

        GameObject obj = Instantiate(objectToSpawn,
                placementIndicator.transform.position, placementIndicator.transform.rotation);

    }
    
   
}
