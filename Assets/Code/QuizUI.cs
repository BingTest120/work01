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

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] choiceTexts;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;

    public Image[] chooseImg;

    public Button[] choiceButtons;
    public Button nextChoice;
    public Button previousChoice;

    private int currentQuestionIndex = 0;

    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
        DisplayQuestion(currentQuestionIndex);

        previousChoice.gameObject.SetActive(false);
    }

    void DisplayQuestion(int index)
    {
        if (quizManager == null || index < 0 || index >= quizManager.questions.Count) return;

        QuizQuestion question = quizManager.questions[index];
        questionText.text = question.question; // แสดงคำถาม

        // กำหนดตัวเลือกให้กับคำถาม
        for (int i = 0; i < choiceTexts.Length; i++)
        {
            choiceTexts[i].text = question.choices[i];
        }

        previousChoice.gameObject.SetActive(index > 0);

        // เรียกฟังก์ชัน SelectChoice ให้เป็นค่าเริ่มต้น (ตัวเลือกที่ยังไม่ได้เลือก)
        SelectChoice(-1); // หรือค่าอื่นที่ไม่ตรงกับตัวเลือก
    }



    void SelectChoice(int index)
    {
        // ซ่อนรูปทั้งหมดก่อน
        foreach (var img in chooseImg)
        {
            img.gameObject.SetActive(false);
        }

        // แสดงรูปเฉพาะที่เลือก
        if (index >= 0 && index < chooseImg.Length)
        {
            chooseImg[index].gameObject.SetActive(true);
        }
    }


    public void OnChoiceSelected(int index)
    {
        SelectChoice(index);
    }



    public void NextQuestion()
    {
        if (currentQuestionIndex < quizManager.questions.Count - 1)
        {
            currentQuestionIndex++;
            DisplayQuestion(currentQuestionIndex);
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

}