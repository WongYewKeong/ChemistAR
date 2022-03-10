using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public struct ReportData
{
    [FirestoreProperty]
    public string ExperimentTitle { get; set; }

    [FirestoreProperty]
    public string Introduction { get; set; }

    [FirestoreProperty]
    public string Procedure { get; set; }

    [FirestoreProperty]
    public string Results { get; set; }

    [FirestoreProperty]
    public string Conclusion { get; set; }

    [FirestoreProperty]
    public string References { get; set; }
}
