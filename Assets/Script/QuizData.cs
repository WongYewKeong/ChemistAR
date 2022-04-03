using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class QuizData
{
    [FirestoreProperty]
    public string Question { get; set; }
}
