using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Scenechange : MonoBehaviour
{
    public GameObject chooseExp, experiment5;
    public GameObject expSem1, expSem2;
    public GameObject prelab;
    
    public GameObject Active, Hide;


    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeExp()
    {
        experiment5.SetActive(true);
        chooseExp.SetActive(false);

    }

    public void ChangeSem1()
    {
        expSem1.SetActive(true);
        expSem2.SetActive(false);

    }

    public void ChangeSem2()
    {
        expSem2.SetActive(true);
        expSem1.SetActive(false);

    }

    public void Prelab()
    {
        experiment5.SetActive(false);
        prelab.SetActive(true);
    }

    public void PrelabBack()
    {
        experiment5.SetActive(true);
        prelab.SetActive(false);
    }

    public void OpenUrl()
    {
        Application.OpenURL("https://chemcollective.oli.cmu.edu/vlabs");
    }

    public void OpenUrlVideo()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=QNCJZKy8v88");
    }

    public void ChangObj()
    {
        Active.SetActive(true);
        Hide.SetActive(false);
    }


}
