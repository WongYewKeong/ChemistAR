using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Scenechange : MonoBehaviour
{

    public void ChangeScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);
    }
    public void ChangeSceneLandscape(string sceneName)
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(sceneName);
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    public void PortraitMode()
    {
        Screen.orientation = ScreenOrientation.Portrait;

    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void OpenUrl()
    {
        Application.OpenURL("https://chemcollective.oli.cmu.edu/vlabs");
    }

    public void OpenUrlVideo(string url)
    {
        Application.OpenURL(url);
    }


}
