using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

    //public GameObject CorrectText;
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;
    [SerializeField]
    private Text textA;
    [SerializeField]
    private Text textB;
    [SerializeField]
    private Text textC;

    [SerializeField]
    private Animator LevelDesign;

    [SerializeField]
    private GameObject CorrectText;

    [SerializeField]
    private GameObject WrongText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    


    void Start()
    {
        //CorrectText.SetActive(false);
        if(unansweredQuestions == null || unansweredQuestions.Count == 0  )
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
        
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;
        textA.text = currentQuestion.ChoiceA;
        textB.text = currentQuestion.ChoiceB;
        textC.text = currentQuestion.ChoiceC;

    }

    IEnumerator TransitionToNextQuestion()
    {
        //unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void UserSelectAButton()
    {
        
        if (currentQuestion.isA)
        {
            Debug.Log("Correct");
            LevelDesign.SetTrigger("Correct");
            LevelControlScript.instance.youWin();

        }
        else
        {
            Debug.Log("Wrong");
            LevelDesign.SetTrigger("Wrong");
            LevelControlScript.instance.youLose();
        }

        //StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectBButton()
    {
        //animator.SetTrigger("False");
        if (currentQuestion.isB)
        {
            Debug.Log("Correct");
            LevelDesign.SetTrigger("Correct");
            LevelControlScript.instance.youWin();

        }
        else
        {
            Debug.Log("Wrong");
            LevelDesign.SetTrigger("Wrong");
            LevelControlScript.instance.youLose();
        }

        //StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectCButton()
    {
        //animator.SetTrigger("False");
        if (currentQuestion.isC)
        {
            Debug.Log("Correct");
            LevelDesign.SetTrigger("Correct");
            LevelControlScript.instance.youWin();

        }
        else
        {
            Debug.Log("Wrong");
            LevelDesign.SetTrigger("Wrong");
            LevelControlScript.instance.youLose();
        }

        //StartCoroutine(TransitionToNextQuestion());
    }
}
