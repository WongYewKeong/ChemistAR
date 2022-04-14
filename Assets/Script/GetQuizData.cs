using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using TMPro;

public class GetQuizData : MonoBehaviour
{
    [SerializeField] private TMP_Text _question;

    [SerializeField] private string sem, exp, question;

    [SerializeField] private List<string> options;

    [SerializeField] private Text Opt1, Opt2, Opt3, Opt4;

    [SerializeField] private int correctAns;

    [SerializeField] private List<Button> buttons;

    [SerializeField] private Color correctCol, wrongCol;
    public GameObject feedback;

    FirebaseFirestore db;

    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        DocumentReference quizRef = db.Collection(sem).Document(exp).Collection("Quiz").Document(question);

        quizRef.GetSnapshotAsync().ContinueWith((task) =>
        {
            var snapshot = task.Result;
            if (snapshot.Exists)
            {

                QuizData quiz = snapshot.ConvertTo<QuizData>();
                _question.text = quiz.Question;
            }
            else
            {
                Debug.Log("No data");
            }
        });

        for (int i = 0; i < options.Count; i++)
        {
            Opt1.text = options[0];
            Opt2.text = options[1];
            Opt3.text = options[2];
            Opt4.text = options[3];
        }

        

    }

    public void CorrectAnswer()
    {
        
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].enabled = false;
            buttons[correctAns].image.color=correctCol;
        }


        feedback.SetActive(true);
    }
    

}
