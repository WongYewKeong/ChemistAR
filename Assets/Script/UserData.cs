using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class UserData
{
    [FirestoreProperty]
    public string Email{ get; set; }

    [FirestoreProperty]
    public string Username { get; set;}
}
