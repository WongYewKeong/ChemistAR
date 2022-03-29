using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Auth;
using System;
public class GetLearningProgress : MonoBehaviour
{

    [SerializeField] private Text _expCompleted;
    [SerializeField] private Text _quizCompleted;
    [SerializeField] private Text _overall;

    int expcomplete;

    public GameObject active, hide;
    FirebaseFirestore db;
    FirebaseAuth auth;
    FirebaseUser user;

    public string key;

    private ListenerRegistration _listenerRegistration;
    // Start is called before the first frame update
    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        auth = FirebaseAuth.DefaultInstance;

        user = auth.CurrentUser;
        DocumentReference progressRef = db.Collection("users").Document(user.UserId).Collection("progress").Document("Learning Progress");

        _listenerRegistration = progressRef.Listen(snapshot =>
          {
              LearningProgressData learningprogress = snapshot.ConvertTo<LearningProgressData>();
              expcomplete = learningprogress.ExperimentCompleted;

              _expCompleted.text = learningprogress.ExperimentCompleted.ToString();
              _quizCompleted.text = learningprogress.QuizzesCompleted.ToString();
              _overall.text = learningprogress.OverallProgress.ToString() + "%";


              Debug.Log(user.UserId);


          });


    }


    void OnDestroy()
    {
        _listenerRegistration.Stop();
    }

    public void UpdateExpComplete()
    {
        DocumentReference progressRef = db.Collection("users").Document(user.UserId).Collection("progress").Document("Learning Progress");

        Dictionary<string, object> updates = new Dictionary<string, object>
    {
        { "ExperimentCompleted",  expcomplete + 1},



    };

        progressRef.UpdateAsync(updates).ContinueWithOnMainThread(task =>
            {
                Debug.Log("Updated progress data");
                PlayerPrefs.SetInt(key, 1);
                PlayerPrefs.Save();


            });
    }

    void Update()
    {
        if (PlayerPrefs.GetInt(key) == 1)
        {
            active.SetActive(true);
            hide.SetActive(false);
        }
        else if (PlayerPrefs.GetInt(key) == 2)
        {
            hide.SetActive(true);
            active.SetActive(false);
        }
    }
    public void UpdateExpUnComplete()
    {
        DocumentReference progressRef = db.Collection("users").Document(user.UserId).Collection("progress").Document("Learning Progress");

        Dictionary<string, object> updates = new Dictionary<string, object>
    {
        { "ExperimentCompleted",  expcomplete - 1 },



    };

        progressRef.UpdateAsync(updates).ContinueWithOnMainThread(task =>
            {
                Debug.Log("Updated progress data");
                PlayerPrefs.SetInt(key, 2);
                PlayerPrefs.Save();


            });
    }

}
