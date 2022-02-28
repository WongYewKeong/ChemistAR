using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Extensions;
using TMPro;
using Firebase;
using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Firebase.Firestore;



public class AuthManager : MonoBehaviour
{
    public GameObject loginpanel, regpanel;
    public Button login, register;
    public TMP_InputField emailLogin, passwordLogin, emailRegister, passReg, username;

    public Text warningtext, warningreg;

    public FirebaseAuth auth;
    public FirebaseUser user;
    FirebaseFirestore db;


    bool isSignedIn = false;

    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

        }
    }

    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                InitializeFirebase();

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

    }

    public void OpenLoginPanel()
    {
        loginpanel.SetActive(true);
        regpanel.SetActive(false);
        warningtext.text = "";

    }

    public void OpenRegPanel()
    {
        loginpanel.SetActive(false);
        regpanel.SetActive(true);
        warningreg.text = "";
    }

    public void LoginUser()
    {
        if (string.IsNullOrEmpty(emailLogin.text) || string.IsNullOrEmpty(passwordLogin.text))
        {
            warningtext.text = "Please Enter Email or Password";
            return;
        }


        SignInUser(emailLogin.text, passwordLogin.text);
    }

    public void RegUser()
    {
        if (string.IsNullOrEmpty(username.text) || string.IsNullOrEmpty(emailRegister.text) || string.IsNullOrEmpty(passReg.text))
        {
            warningreg.text = "Please Enter All The Field Above";
            return;
        }

        CreateUser(emailRegister.text, passReg.text, username.text);
    }

    void CreateUser(string email, string password, string Username)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                warningreg.text = "Registration failed";
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            db = FirebaseFirestore.DefaultInstance;
            DocumentReference docRef = db.Collection("users").Document(newUser.UserId);

            Dictionary<string, object> users = new Dictionary<string, object>
{
        { "Username", Username },
        { "Email", email }

};
            docRef.SetAsync(users).ContinueWithOnMainThread(task =>
            {
                Debug.Log("Added data to the document in the users collection.");
            });


        });
    }

    public void SignInUser(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                warningtext.text = "Login Failed";
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            SceneManager.LoadScene(1);
        });
    }

    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
                isSignedIn = true;


            }
        }
    }

    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }

    bool isSigned = false;
    void Update()
    {
        if (isSignedIn)
        {
            if (!isSigned)
            {
                isSigned = true;

                SceneManager.LoadScene(1);

            }
        }
    }



}
