using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Auth;
using TMPro;

public class GetUserData : MonoBehaviour
{

    [SerializeField] private Text _nameText;

    [SerializeField] private Text _emailText;

    public TMP_InputField userName;

    FirebaseFirestore db;
    FirebaseAuth auth;
    FirebaseUser user;

    private ListenerRegistration _listenerRegistration;

    // Start is called before the first frame update
    void Start()
    {


        db = FirebaseFirestore.DefaultInstance;
        auth = FirebaseAuth.DefaultInstance;

        user = auth.CurrentUser;
        _listenerRegistration = db.Collection("users").Document(user.UserId).Listen(snapshot =>
          {

              UserData userdata = snapshot.ConvertTo<UserData>();
              _nameText.text = userdata.Username;
              _emailText.text = userdata.Email;
              userName.text = userdata.Username;

              Debug.Log(user.UserId);
          });

    }

    void OnDestroy()
    {
        _listenerRegistration.Stop();
    }

    public void UpdateUser()
    {
        DocumentReference userRef = db.Collection("users").Document(user.UserId);
        Dictionary<string, object> updates = new Dictionary<string, object>
    {
        { "Username",  userName.text}
    };

        userRef.UpdateAsync(updates).ContinueWithOnMainThread(task =>
        {
            Debug.Log("Updated data");
        });
    }




}
