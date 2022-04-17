using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Auth;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public TMP_Text QuestionTxt;
    public Text ScoreTxt;

    public GameObject correctText, wrongText;
    int totalQuestions = 0;
    public int score;
    public TMP_Text QuesNo;
    int i = 1;

    public string doc;
    FirebaseFirestore db;
    FirebaseAuth auth;
    FirebaseUser user;


    private void Start()
    {

        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
        QuesNo.text = "Questions " + i;
    }



    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
        db = FirebaseFirestore.DefaultInstance;
        auth = FirebaseAuth.DefaultInstance;
        user = auth.CurrentUser;
        DocumentReference quizRef = db.Collection("users").Document(user.UserId).Collection("progress").Document(doc);

        Dictionary<string, object> quizScore = new Dictionary<string, object>
    {
            { "Score", score }
    };
        quizRef.SetAsync(quizScore).ContinueWithOnMainThread(task =>
        {
            Debug.Log("Added data to the document in the users collection.");
        });
    }

    public void correct()
    {
        //when you are right
        score += 1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(waitForNext());
    }

    public void wrong()
    {
        //when you answer wrong
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(waitForNext());
    }

    IEnumerator waitForNext()
    {
        yield return new WaitForSeconds(2);
        generateQuestion();
        QuesNo.text = "Questions " + ++i;
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {

            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            correctText.SetActive(false);
            wrongText.SetActive(false);
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }


    }
}
