using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public struct UserData
{
    [FirestoreProperty]
    public string Email{ get; set; }

    [FirestoreProperty]
    public string Username { get; set;}
}
