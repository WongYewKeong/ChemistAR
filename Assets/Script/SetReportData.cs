using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Auth;
using TMPro;


public class SetReportData : MonoBehaviour
{
    [SerializeField] private TMP_InputField _experimentTitle;
    [SerializeField] private TMP_InputField _Introduction;
    [SerializeField] private TMP_InputField _Procedure;
    [SerializeField] private TMP_InputField _Results;
    [SerializeField] private TMP_InputField _Conclusion;
    [SerializeField] private TMP_InputField _References;

    [SerializeField] private TMP_Text expname;
    [SerializeField] private string docName;

    public GameObject AddedReport, AddReportUI;

    FirebaseFirestore db;
    FirebaseAuth auth;
    FirebaseUser user;

    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        auth = FirebaseAuth.DefaultInstance;
        user = auth.CurrentUser;
        Debug.Log(user.UserId);

        _experimentTitle.text = expname.text;

    }

    // Update is called once per frame
    public void AddReport()
    {

        ReportData reportData = new ReportData
        {
            ExperimentTitle = _experimentTitle.text,
            Introduction = _Introduction.text,
            Procedure = _Procedure.text,
            Results = _Results.text,
            Conclusion = _Conclusion.text,
            References = _References.text

        };
        DocumentReference reportRef = db.Collection("users").Document(user.UserId).Collection("report").Document(docName);
        reportRef.SetAsync(reportData);

        Debug.Log("Added data");
        AddedReport.SetActive(true);
        AddReportUI.SetActive(false);
    }
}
