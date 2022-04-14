using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressExp : MonoBehaviour
{
    public Text progressText;

    int progress = 0;
    int maximum = 100;
    public Image mask;

    public void progressInt(int steps)
    {
        progress += 100 / steps;
        progressText.text = progress.ToString() + "%";
        float fillAmount = (float)progress / (float)maximum;
        mask.fillAmount = fillAmount;
    }

    public void endExperiment()
    {
        progressText.text = "100%";
        mask.fillAmount = 1;
    }

}
