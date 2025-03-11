using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public List<QuizQuestion> questions = new List<QuizQuestion>();

    void Start()
    {
        LoadQuestions(); // โหลดข้อมูลโจทย์
        DisplayQuestion(0); // แสดงข้อแรก
    }

    void LoadQuestions()
    {
        questions.Add(new QuizQuestion
        {
            question = "ประเทศไทยมีกี่จังหวัด?",
            choices = new string[] { "A. 76", "B. 77", "C. 78", "D. 79" },
            correctAnswerIndex = 3 // B. 77 คือคำตอบที่ถูกต้อง
        });

        questions.Add(new QuizQuestion
        {
            question = "เมืองหลวงของญี่ปุ่นคือ?",
            choices = new string[] { "A. ปักกิ่ง", "B. โซล", "C. โตเกียว", "D. ฮานอย" },
            correctAnswerIndex = 2 // C. โตเกียว คือคำตอบที่ถูกต้อง
        });

        // เพิ่มอีก 8 ข้อ...
    }

    void DisplayQuestion(int index)
    {
        if (index < 0 || index >= questions.Count) return;

        QuizQuestion q = questions[index];

        Debug.Log("คำถาม: " + q.question);
        for (int i = 0; i < q.choices.Length; i++)
        {
            Debug.Log(q.choices[i]);
        }
    }
}
