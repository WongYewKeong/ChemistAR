using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class QuizData
{
    [FirestoreProperty]
    public int Score { get; set; }
}
