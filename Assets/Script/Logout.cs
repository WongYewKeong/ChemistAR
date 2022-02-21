using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;

     private void Start() {
      auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    
    public void LogOut(string scenename)
{

  auth.SignOut();
  
SceneManager.LoadScene(scenename);
  
  
}
}

