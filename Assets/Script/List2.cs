using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;



public class List2 : MonoBehaviour
{

    [Serializable]
    public struct Experiment
    {
        public string Exp;
        public string Name;

    }

    [SerializeField] Experiment[] allExp;
    public GameObject main, tutorial, exp1, exp2, exp3, exp6, exp7, exp8, exp9;

    void Start()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;

        int N = allExp.Length;

        for (int i = 0; i < N; i++)
        {
            g = Instantiate(buttonTemplate, transform);
            g.transform.GetChild(0).GetComponent<Text>().text = allExp[i].Exp;
            g.transform.GetChild(1).GetComponent<Text>().text = allExp[i].Name;

            /*g.GetComponent <Button> ().onClick.AddListener (delegate() {
				ItemClicked (i);
			});*/
            g.GetComponent<Button>().AddEventListener(i, ItemClicked);
        }

        Destroy(buttonTemplate);
    }

    void ItemClicked(int itemIndex)
    {
        Debug.Log("------------item " + itemIndex + " clicked---------------");
        Debug.Log("exp " + allExp[itemIndex].Exp);
        Debug.Log("name " + allExp[itemIndex].Name);

        if (itemIndex == 0)
        {
            main.SetActive(false);
            tutorial.SetActive(true);
        }
        else if (itemIndex == 1)
        {
            main.SetActive(false);
            exp1.SetActive(true);
        }
        else if (itemIndex == 2)
        {
            main.SetActive(false);
            exp2.SetActive(true);
        }
        else if (itemIndex == 3)
        {
            main.SetActive(false);
            exp3.SetActive(true);
        }
        else if (itemIndex == 4)
        {
            SceneManager.LoadScene("Experiment4");
        }
        else if (itemIndex == 5)
        {
            SceneManager.LoadScene("Experiment5");
        }
        else if (itemIndex == 6)
        {
            main.SetActive(false);
            exp6.SetActive(true);
        }
        else if (itemIndex == 7)
        {
            main.SetActive(false);
            exp7.SetActive(true);
        }
        else if (itemIndex == 8)
        {
            main.SetActive(false);
            exp8.SetActive(true);
        }
        else if (itemIndex == 9)
        {
            main.SetActive(false);
            exp9.SetActive(true);
        }
    }
}
