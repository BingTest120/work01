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
        //ข้อ 2 ()
        questions.Add(new QuizQuestion
        {
            question = "1. ภายหลังจากที่มีการประเมินผลงานไปแล้วจำเป็นต้องมีการแจ้งผลการประเมินนั้นหรือไม่",
            choices = new string[] { 
            "ไม่จำเป็นเพราะเป็นการเสียเวลา", 
            "จำเป็นเพราะเปิดโอกาสให้ทุกฝ่ายทราบผลและนำไปปรับปรุง", 
            "ไม่จำเป็นเพราะทุกฝ่ายย่อมทราบพฤติกรรมการทำงานของตนเอง", 
            "จำเป็นเพราะจัดสรรงบประมาณส่วนนี้ไว้แล้ว" 
            },
            correctAnswerIndex = 0 // ก. มาจากการสำรวจความต้องการของสมาชิกส่วนใหญ่
        });

        //ข้อ 1 (2)
        questions.Add(new QuizQuestion
        {
            question = "1. การกำหนดนโยบายในการบริหารงานที่ดีของสหกรณ์ คือ",
            choices = new string[] { 
            "มาจากการสำรวจความต้องการของสมาชิกส่วนใหญ่", 
            "มาจากมติของคณะกรรมการก็เพียงพอแล้ว", 
            "มาจากฝ่ายจัดการของสหกรณ์ก็พอแล้ว", 
            "มาจากเจ้าหน้าที่ส่งเสริมสหกรณ์เหมาะสมที่สุดแล้ว" 
            },
            correctAnswerIndex = 0 // ก. มาจากการสำรวจความต้องการของสมาชิกส่วนใหญ่
        });

        
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
