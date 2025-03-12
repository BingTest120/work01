using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // ต้องใช้สำหรับ UI Button

public class QuizUI : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] choiceTexts; // เก็บตัวเลือก 4 ข้อ
    public Button[] choiceButtons; // ปุ่มตัวเลือก 4 ปุ่ม

    public Image[] chooseChoice; // ปุ่มตัวเลือก 4 ปุ่ม

    public Button choiceConfirmed;

    public Button previousChoice;

    private int currentQuestionIndex = 0;
    private QuizManager quizManager;

    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
        DisplayQuestion(currentQuestionIndex);

        // กำหนด Event ให้ปุ่มเมื่อกด
     
        
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            int choiceIndex = i; // ต้องใช้ตัวแปรใหม่ป้องกันปัญหา Closure
            choiceButtons[i].onClick.AddListener(() => CheckAnswer(choiceIndex));
        }
       

        choiceConfirmed.gameObject.SetActive(false);

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            int index = i; // ใช้ตัวแปร local เพื่อป้องกันปัญหา closure
            choiceButtons[i].onClick.AddListener(() => selectedChoice(index));
        }

    }

    void selectedChoice(int index)
    {
        foreach (Image img in chooseChoice)
        {
            img.gameObject.SetActive(false);
        }

        // แสดงเฉพาะที่เลือก
        chooseChoice[index].gameObject.SetActive(true);
        choiceConfirmed.gameObject.SetActive(true);
    }


    void DisplayQuestion(int index)
    {
        if (quizManager == null || index >= quizManager.questions.Count) return;

        QuizQuestion q = quizManager.questions[index];
        questionText.text = q.question;

        for (int i = 0; i < choiceTexts.Length; i++)
        {
            choiceTexts[i].text = q.choices[i];
        }

    }
    
    void CheckAnswer(int selectedIndex)
    {
        QuizQuestion q = quizManager.questions[currentQuestionIndex];

        if (selectedIndex == q.correctAnswerIndex)
        {
            Debug.Log("ถูก");
        }
        else
        {
            Debug.Log("ผิด");
        }

        // ไปยังคำถามถัดไป (ถ้ามี)
       // NextQuestion();
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < quizManager.questions.Count)
        {
            DisplayQuestion(currentQuestionIndex);
        }
        else
        {
            Debug.Log("จบเกม!");
        }
    }
}
