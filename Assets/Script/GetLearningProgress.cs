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
    int quizcomplete;
    double overall;

    int total;
    public GameObject active, hide, completed;
    FirebaseFirestore db;
    FirebaseAuth auth;
    FirebaseUser user;

    public string key;

    private ListenerRegistration _listenerRegistration;

    void Awake()
    {
        db = FirebaseFirestore.DefaultInstance;
        auth = FirebaseAuth.DefaultInstance;

        user = auth.CurrentUser;
        DocumentReference progressRef = db.Collection("users").Document(user.UserId).Collection("progress").Document("Learning Progress");

        _listenerRegistration = progressRef.Listen(snapshot =>
          {
              LearningProgressData learningprogress = snapshot.ConvertTo<LearningProgressData>();
              expcomplete = learningprogress.ExperimentCompleted;
              quizcomplete = learningprogress.QuizzesCompleted;

              total = expcomplete + quizcomplete;
              Debug.Log(total);
              overall = total / 18.0f * 100.0f;
              _overall.text = Math.Ceiling(overall).ToString() + "%";
              Debug.Log(overall);

              _expCompleted.text = learningprogress.ExperimentCompleted.ToString();
              _quizCompleted.text = learningprogress.QuizzesCompleted.ToString();

              Dictionary<string, object> updates = new Dictionary<string, object>
            {
                { "OverallProgress",  Math.Ceiling(overall) }
            };

              progressRef.UpdateAsync(updates).ContinueWithOnMainThread(task =>
                  {
                      Debug.Log("Updated progress data");
                  });
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
        { "ExperimentCompleted",  expcomplete + 1}

    };

        progressRef.UpdateAsync(updates).ContinueWithOnMainThread(task =>
            {
                Debug.Log("Updated progress data");
                PlayerPrefs.SetInt(key, 1);
                PlayerPrefs.Save();

            });

    }

    private void Update()
    {

        if (PlayerPrefs.GetInt(key) == 1)
        {
            active.SetActive(true);
            hide.SetActive(false);
            completed.SetActive(true);

        }
        else
        {
            hide.SetActive(true);
            active.SetActive(false);
            completed.SetActive(false);
        }

    }
    public void UpdateExpUnComplete()
    {
        DocumentReference progressRef = db.Collection("users").Document(user.UserId).Collection("progress").Document("Learning Progress");

        Dictionary<string, object> updates = new Dictionary<string, object>
    {
        { "ExperimentCompleted",  expcomplete - 1 }

    };

        progressRef.UpdateAsync(updates).ContinueWithOnMainThread(task =>
            {
                Debug.Log("Updated progress data");
                PlayerPrefs.DeleteKey(key);
                PlayerPrefs.Save();


            });
    }

    public void UpdateExp4Complete()
    {
        DocumentReference progressRef = db.Collection("users").Document(user.UserId).Collection("progress").Document("Learning Progress");

        Dictionary<string, object> updates = new Dictionary<string, object>
    {
        { "ExperimentCompleted",  expcomplete + 1},



    };
        if (PlayerPrefs.GetInt("Exp4_s2") != 1)
        {
            progressRef.UpdateAsync(updates).ContinueWithOnMainThread(task =>
                {
                    Debug.Log("Updated progress data");
                    PlayerPrefs.SetInt(key, 1);
                    PlayerPrefs.Save();

                });
        }
    }

    public void UpdateExp5Complete()
    {
        DocumentReference progressRef = db.Collection("users").Document(user.UserId).Collection("progress").Document("Learning Progress");

        Dictionary<string, object> updates = new Dictionary<string, object>
    {
        { "ExperimentCompleted",  expcomplete + 1},



    };
        if (PlayerPrefs.GetInt("Exp5_s2") != 1)
        {
            progressRef.UpdateAsync(updates).ContinueWithOnMainThread(task =>
               {
                   Debug.Log("Updated progress data");
                   PlayerPrefs.SetInt(key, 1);
                   PlayerPrefs.Save();
               });
        }
    }

    public void UpdateQuizComplete()
    {
        DocumentReference progressRef = db.Collection("users").Document(user.UserId).Collection("progress").Document("Learning Progress");

        Dictionary<string, object> updates = new Dictionary<string, object>
    {
        { "QuizzesCompleted",  quizcomplete + 1},


    };
        if (PlayerPrefs.GetInt(key) != 1)
        {
            progressRef.UpdateAsync(updates).ContinueWithOnMainThread(task =>
               {
                   Debug.Log("Updated progress data");
                   PlayerPrefs.SetInt(key, 1);
                   PlayerPrefs.Save();
               });
        }
    }

}
