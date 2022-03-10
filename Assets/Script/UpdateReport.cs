using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Auth;
using TMPro;

public class UpdateReport : MonoBehaviour
{
    [SerializeField] private TMP_InputField _experimentTitleInput;
    [SerializeField] private TMP_InputField _IntroductionInput;
    [SerializeField] private TMP_InputField _ProcedureInput;
    [SerializeField] private TMP_InputField _ResultsInput;
    [SerializeField] private TMP_InputField _ConclusionInput;
    [SerializeField] private TMP_InputField _ReferencesInput;
    [SerializeField] private string docName;

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
              _experimentTitleInput.text = reportdata.ExperimentTitle;
              _IntroductionInput.text = reportdata.Introduction;
              _ProcedureInput.text = reportdata.Procedure;
              _ResultsInput.text = reportdata.Results;
              _ConclusionInput.text = reportdata.Conclusion;
              _ReferencesInput.text = reportdata.References;

          });
    }

    void OnDestroy()
    {
        _listenerRegistration.Stop();
    }

    // Update is called once per frame
    public void UpdateReportData()
    {
        DocumentReference reportRef = db.Collection("users").Document(user.UserId).Collection("report").Document(docName);
         Dictionary<string, object> updates = new Dictionary<string, object>
    {
        { "Introduction",  _IntroductionInput.text},
        { "Procedure",  _ProcedureInput.text},
        { "Results",  _ResultsInput.text},
        { "Conclusion",  _ConclusionInput.text},
        { "References",  _ReferencesInput.text},
    };

        reportRef.UpdateAsync(updates).ContinueWithOnMainThread(task =>
        {
            Debug.Log("Updated data");
        });
    }
}
