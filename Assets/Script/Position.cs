using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public GameObject GO;

    public void Reset()
    {
        GO.transform.localPosition = Vector3.zero;
        GO.transform.localEulerAngles = Vector3.zero;
    }

}
