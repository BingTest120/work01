using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // ทำให้แสดงใน Inspector ของ Unity
public class QuizQuestion
{
    public string question;
    public string[] choices;
    public int correctAnswerIndex; // เก็บ index ของคำตอบที่ถูกต้อง
}
