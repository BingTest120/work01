using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizUI : MonoBehaviour
{
    private QuizManager quizManager;

    public GameObject quizArea;
    public GameObject quizResultArea;
    public GameObject confirmChoiceArea;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] choiceTexts;
    public TextMeshProUGUI nameUser;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;

    public Image[] chooseImg;
    public Button[] choiceButtons;
    public GameObject nextChoice;
    public GameObject previousChoice;


    private int currentQuestionIndex = 0;
    private List<int> selectedChoices = new List<int>();
    private List<int> correctScores = new List<int>();

    void Start()
    {
        userName();

        quizManager = FindObjectOfType<QuizManager>();
        DisplayQuestion(currentQuestionIndex);

        previousChoice.gameObject.SetActive(false);
        nextChoice.SetActive(false);
    }

    void DisplayQuestion(int index)
    {
        if (quizManager == null || index < 0 || index >= quizManager.questions.Count) return;

        QuizQuestion question = quizManager.questions[index];
        questionText.text = question.question;

        for (int i = 0; i < choiceTexts.Length; i++)
        {
            choiceTexts[i].text = question.choices[i];
        }

        previousChoice.gameObject.SetActive(index > 0);

        int selectedIndex = -1;
        if (selectedChoices.Count > index)
        {
            selectedIndex = selectedChoices[index];
        }

        SelectChoice(selectedIndex);
    }

    void SelectChoice(int index)
    {
        foreach (var img in chooseImg)
        {
            img.gameObject.SetActive(false);
        }

        if (index >= 0 && index < chooseImg.Length)
        {
            chooseImg[index].gameObject.SetActive(true);
            nextChoice.SetActive(true);
        }
        else
        {
            nextChoice.SetActive(false);
        }
    }

    public void OnChoiceSelected(int index)
    {
        if (selectedChoices.Count <= currentQuestionIndex)
        {
            selectedChoices.Add(index);
        }
        else
        {
            selectedChoices[currentQuestionIndex] = index;
        }

        int score = CheckAnswer(index);
        if (correctScores.Count <= currentQuestionIndex)
        {
            correctScores.Add(score);
        }
        else
        {
            correctScores[currentQuestionIndex] = score;
        }

        SelectChoice(index);
    }

    int CheckAnswer(int selectedIndex)
    {
        QuizQuestion question = quizManager.questions[currentQuestionIndex];

        return selectedIndex == question.correctAnswerIndex ? 1 : 0;
    }

    public void NextQuestion()
    {
        if (currentQuestionIndex < quizManager.questions.Count - 1)
        {
            currentQuestionIndex++;
            DisplayQuestion(currentQuestionIndex);
        }
        else
        {
            confirmChoiceArea.SetActive(true);
        }
    }

    public void PreviousQuestion()
    {
        if (currentQuestionIndex > 0)
        {
            currentQuestionIndex--;
            DisplayQuestion(currentQuestionIndex);
        }
    }

    public void confirmChoice()
    {
        int totalScore = 0;
        foreach (int score in correctScores)
        {
            totalScore += score;
        }

        score1.text = "ทำได้ทั้งหมด " + totalScore.ToString() + " ข้อ";
        score2.text = totalScore.ToString();
        score3.text = "จากแบบทดสอบทั้งหมด " + quizManager.questions.Count.ToString() + " ข้อ";

        quizArea.SetActive(false);
        quizResultArea.SetActive(true);
    }

    public void backQuiz()
    {
        confirmChoiceArea.SetActive(false);
    }

    public void userName()
    {
        string firstName = PlayerPrefs.GetString("FirstName", "");
        string lastName = PlayerPrefs.GetString("LastName", "");

        if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
        {
            nameUser.text = $"{firstName} {lastName}";
        }
        else
        {
            nameUser.text = "(ยังไม่มีข้อมูล)";
        }
    }
}
