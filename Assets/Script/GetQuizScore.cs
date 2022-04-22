using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Auth;

public class GetQuizScore : MonoBehaviour
{
    FirebaseFirestore db;
    FirebaseAuth auth;
    FirebaseUser user;
    [SerializeField] private Text scoreText;
    [SerializeField] private string doc;
    [SerializeField] private GameObject exp;

    public void GetScore()
    {
        db = FirebaseFirestore.DefaultInstance;
        auth = FirebaseAuth.DefaultInstance;

        user = auth.CurrentUser;
        DocumentReference quizRef = db.Collection("users").Document(user.UserId).Collection("progress").Document(doc);

        quizRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
    {
        DocumentSnapshot snapshot = task.Result;
        if (snapshot.Exists)
        {
            QuizData quizData = snapshot.ConvertTo<QuizData>();
            scoreText.text = quizData.Score.ToString();
            exp.SetActive(true);
        }
        else
        {
            exp.SetActive(false);
        }
    });


    }


}
