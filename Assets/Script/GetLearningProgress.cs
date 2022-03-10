using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Auth;
public class GetLearningProgress : MonoBehaviour
{

    [SerializeField] private Text _expCompleted;
    [SerializeField] private Text _quizCompleted;
    [SerializeField] private Text _overall;

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
        DocumentReference progressRef = db.Collection("users").Document(user.UserId).Collection("progress").Document("Learning Progress");

        _listenerRegistration = progressRef.Listen(snapshot =>
          {

              LearningProgressData learningprogress = snapshot.ConvertTo<LearningProgressData>();
              _expCompleted.text = learningprogress.ExperimentCompleted.ToString();
              _quizCompleted.text = learningprogress.QuizzesCompleted.ToString();
              _overall.text = learningprogress.OverallProgress.ToString() + "%";
              
              Debug.Log(user.UserId);


          });
    }

    // Update is called once per frame
    void OnDestroy()
    {
        _listenerRegistration.Stop();
    }
}
