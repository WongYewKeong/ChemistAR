using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text procedure;
    
    private Queue<string> sentences;

    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartProcedure(ProcedureText procedureText)
    {
        Debug.Log("Started");

        sentences.Clear();

        foreach (string sentence in procedureText.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndProcedure();
            return;
        }
        string sentence = sentences.Dequeue();
        procedure.text = sentence;
        
        
    }

    void EndProcedure()
    {
        Debug.Log("End of Experiment");
        
    }

}
