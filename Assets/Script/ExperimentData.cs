using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public struct ExperimentData

{
    [FirestoreProperty]
    public string ExpName { get; set; }

    [FirestoreProperty]
    public string Introduction { get; set; }

    [FirestoreProperty]
    public string Materials { get; set; }

    [FirestoreProperty]
    public string Objective { get; set; }

    [FirestoreProperty]
    public string Procedure { get; set; }
}
