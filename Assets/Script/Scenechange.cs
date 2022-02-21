using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Scenechange : MonoBehaviour
{
    public GameObject chooseExp,experiment1;
    public GameObject expSem1,expSem2;
    
        
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
            experiment1.SetActive(true);
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

   
}
