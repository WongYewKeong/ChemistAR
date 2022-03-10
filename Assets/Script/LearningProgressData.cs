using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public struct LearningProgressData
{
    [FirestoreProperty]
    public int ExperimentCompleted { get; set; }

    [FirestoreProperty]
    public int QuizzesCompleted { get; set; }

    [FirestoreProperty]
    public int OverallProgress { get; set; }
}
