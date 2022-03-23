using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressExp : MonoBehaviour
{
    public Text progressText;
    int progress = 0;

    public void progressInt()
    {
        progress += 100 / 8;
        progressText.text = progress.ToString() + "%";
    }

    public void endExperiment()
    {
        progressText.text="100%";
    }

}
