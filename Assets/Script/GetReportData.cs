using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Auth;
using TMPro;

public class GetReportData : MonoBehaviour
{

    [SerializeField] private TMP_Text _experimentTitle;

    [SerializeField] private TMP_Text _Introduction;
    [SerializeField] private TMP_Text _Procedure;
    [SerializeField] private TMP_Text _Results;
    [SerializeField] private TMP_Text _Conclusion;
    [SerializeField] private TMP_Text _References;
    [SerializeField] private string docName;

    

    public GameObject ReportEmpty, ReportRecord;

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
        DocumentReference reportRef = db.Collection("users").Document(user.UserId).Collection("report").Document(docName);

        _listenerRegistration = reportRef.Listen(snapshot =>
          {

              ReportData reportdata = snapshot.ConvertTo<ReportData>();
              _experimentTitle.text = reportdata.ExperimentTitle;
              _Introduction.text = reportdata.Introduction;
              _Procedure.text = reportdata.Procedure;
              _Results.text = reportdata.Results;
              _Conclusion.text = reportdata.Conclusion;
              _References.text = reportdata.References;

              

              Debug.Log(user.UserId);


          });
    }


    void OnDestroy()
    {
        _listenerRegistration.Stop();
    }


    public void checkSnapshot()
    {
        db = FirebaseFirestore.DefaultInstance;
        auth = FirebaseAuth.DefaultInstance;

        user = auth.CurrentUser;
        DocumentReference reportRef = db.Collection("users").Document(user.UserId).Collection("report").Document(docName);

        reportRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
{
    DocumentSnapshot snapshot = task.Result;
    if (snapshot.Exists)
    {
        ReportRecord.SetActive(true);
        ReportEmpty.SetActive(false);
    }
    else
    {
        
        ReportRecord.SetActive(false);
        ReportEmpty.SetActive(true);
    }
});
    }
}
