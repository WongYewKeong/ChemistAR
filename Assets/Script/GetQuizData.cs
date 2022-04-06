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

    [SerializeField] private string sem,exp,question;

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
                _question.text=quiz.Question;
            }
            else
            {
                Debug.Log("No data");
            }
        });
    }
}
