using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressExp : MonoBehaviour
{
    int progress = 0;
    int maximum = 100;
    public Image mask;

    public void progressInt(int steps)
    {
        progress += 100 / steps;
        float fillAmount = (float)progress / (float)maximum;
        mask.fillAmount = fillAmount;
    }

    public void endExperiment()
    {
        mask.fillAmount = 1;
    }

}
