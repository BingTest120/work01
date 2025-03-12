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

        //ข้อ 2 (4)
        questions.Add(new QuizQuestion
        {
            question = "2. บุคคลที่ทำให้สหกรณ์ประสบความสำเร็จ คือ",
            choices = new string[] { 
            "เจ้าหน้าที่สหกรณ์", 
            "คณะกรรมการ", 
            "สมาชิก", 
            "ทุกข้อถูกต้อง" 
            },
            correctAnswerIndex = 3 // ง. ทุกข้อถูกต้อง
        });

        //ข้อ 3 (5)
        questions.Add(new QuizQuestion
        {
            question = "3. ภารกิจหลักของสหกรณ์ คือ",
            choices = new string[] { 
            "พัฒนาคุณภาพชีวิตสมาชิก", 
            "พัฒนาอาชีพสมาชิก", 
            "วางนโยบายเพื่อแก้ปัญหาให้สมาชิก", 
            "ถูกทุกข้อ" 
            },
            correctAnswerIndex = 3 // ง.ถูกทุกข้อ
        });




     /*ตัวอย่าง

        //ข้อ 1 ()
        questions.Add(new QuizQuestion
        {
            question = "",
            choices = new string[] { 
            "", 
            "", 
            "", 
            "" 
            },
            correctAnswerIndex = 0 // ก. มาจากการสำรวจความต้องการของสมาชิกส่วนใหญ่
        });

    */

        
    }

    void DisplayQuestion(int index)
    {
        if (index < 0 || index >= questions.Count) return;

        QuizQuestion q = questions[index];
    }
}
