using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Auth;

public class GetUserData : MonoBehaviour
{

    [SerializeField] private Text _nameText;

    [SerializeField] private Text _emailText;

    FirebaseFirestore db;
    FirebaseAuth auth;
    FirebaseUser user;

    // Start is called before the first frame update
    void Start()
    {


        db = FirebaseFirestore.DefaultInstance;
        auth = FirebaseAuth.DefaultInstance;

        user=auth.CurrentUser;
        db.Collection("users").Document(user.UserId).GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {

            UserData userdata = task.Result.ConvertTo<UserData>();
            _nameText.text = userdata.Username;
            _emailText.text = userdata.Email;

            Debug.Log(user.UserId);
        });

    }






}
