using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Auth;
using TMPro;

public class GetExpData : MonoBehaviour
{

    [SerializeField] private TMP_Text _experimentName;

    [SerializeField] private TMP_Text _Objective;
    [SerializeField] private TMP_Text _Introduction;
    [SerializeField] private TMP_Text IntroductionText;

    [SerializeField] private TMP_Text _Materials;
    [SerializeField] private TMP_Text _Procedure;

    FirebaseFirestore db;
    FirebaseAuth auth;
    FirebaseUser user;
    private ListenerRegistration _listenerRegistration;

    [SerializeField] private string collection, doc;
    // Start is called before the first frame update
    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        auth = FirebaseAuth.DefaultInstance;

        user = auth.CurrentUser;

        DocumentReference expRef = db.Collection(collection).Document(doc);

        _listenerRegistration = expRef.Listen(snapshot =>
  {


      ExperimentData expdata = snapshot.ConvertTo<ExperimentData>();
      _experimentName.text = expdata.ExpName;
      _Introduction.text = expdata.Introduction.Replace("nn","\n").Replace("//","nn");
      _Materials.text = expdata.Materials.Replace("nn","\n").Replace("//","nn");
      _Objective.text = expdata.Objective.Replace("nn","\n");
      _Procedure.text = expdata.Procedure.Replace("nn","\n").Replace("//","nn");



      Debug.Log(user.UserId);



  });
    }

    // Update is called once per frame
    void OnDestroy()
    {
        _listenerRegistration.Stop();
    }

    public void getIntro(){
        DocumentReference expRef = db.Collection(collection).Document(doc);

        _listenerRegistration = expRef.Listen(snapshot =>
  {


      ExperimentData expdata = snapshot.ConvertTo<ExperimentData>();
      
      IntroductionText.text = expdata.Introduction.Replace("nn","\n");
      


      Debug.Log(user.UserId);



  });
    }
}
