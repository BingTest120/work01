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
            correctAnswerIndex = 0 // ก.มาจากการสำรวจความต้องการของสมาชิกส่วนใหญ่
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
            correctAnswerIndex = 3 // ง.ทุกข้อถูกต้อง
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

        //ข้อ 4 (7)
        questions.Add(new QuizQuestion
        {
            question = "4. ธุรกิจของสหกรณ์มีจุดอ่อน คือ",
            choices = new string[] { 
            "มีสมาชิกเป็นเจ้าของ", 
            "อิงระบบราชการ", 
            "มีคณะกรรมการบริหาร", 
            "พนักงานไม่ได้เป็นเจ้าของ" 
            },
            correctAnswerIndex = 1 // ข.อิงระบบราชการ
        });

        //ข้อ 5 (9)
        questions.Add(new QuizQuestion
        {
            question = "5. การบริหารงานสหกรณ์ ข้อความใดกล่าวถูกต้อง",
            choices = new string[] { 
            "มีการแบ่งหน้าที่ฝ่ายต่าง ๆ สอดคล้องกับการปฏิบัติงาน", 
            "ควรให้เงินกู้แก่สมาชิกให้มากที่สุดเพื่อเป็นการเอาใจสมาชิก", 
            "การส่งเสริมอาชีพสมาชิกไม่ใช่หน้าที่ของสหกรณ์", 
            "การจัดกิจกรรมดูแลสุขภาพของสมาชิกเป็นหน้าที่ขององค์การ\nบริหารส่วนตำบล" 
            },
            correctAnswerIndex = 0 // ก.มีการแบ่งหน้าที่ฝ่ายต่าง ๆ สอดคล้องกับการปฏิบัติงาน
        });

        //ข้อ 6 (11)
        questions.Add(new QuizQuestion
        {
            question = "6. วิธีการในการแก้ปัญหาข้อขัดแย้ง ควรใช้วิธีใด",
            choices = new string[] { 
            "แก้ปัญหาโดยหัวหน้า", 
            "แก้ปัญหาโดยลูกน้อง", 
            "แก้ปัญหาร่วมกัน", 
            "แก้ปัญหาโดยองค์กร" 
            },
            correctAnswerIndex = 2 // ค.แก้ปัญหาร่วมกัน
        });

        //ข้อ 7 (1)
        questions.Add(new QuizQuestion
        {
            question = "7. หลักสหกรณ์มีกี่ข้อ",
            choices = new string[] { 
            "4 ข้อ", 
            "5 ข้อ", 
            "6 ข้อ", 
            "7 ข้อ" 
            },
            correctAnswerIndex = 3 // ง.7 ข้อ
        });

        //ข้อ 8 (13)
        questions.Add(new QuizQuestion
        {
            question = "8. ธุรกิจรวมกันซื้อหมายถึง",
            choices = new string[] { 
            "สหกรณ์ซื้อสินค้ามาจำหน่ายให้สมาชิก", 
            "สมาชิกขายสินค้าให้สหกรณ์", 
            "สมาชิกซื้อสินค้าในหมู่บ้าน", 
            "สหกรณ์ซื้อผลผลิตสมาชิก" 
            },
            correctAnswerIndex = 0 // ก.สหกรณ์ซื้อสินค้ามาจำหน่ายให้สมาชิก
        });

        //ข้อ 9 (14)
        questions.Add(new QuizQuestion
        {
            question = "9. ธุรกิจรวมกันขายหมายถึง",
            choices = new string[] { 
            "สหกรณ์ซื้อสินค้ามาจำหน่ายให้สมาชิก", 
            "สมาชิกขายผลผลิตให้สหกรณ์", 
            "สมาชิกซื้อสินค้าในหมู่บ้าน", 
            "สหกรณ์ขายสินค้าให้ลูกค้าทั่วไป" 
            },
            correctAnswerIndex = 1 // ข.สมาชิกขายผลผลิตให้สหกรณ์
        });

        //ข้อ 10 (15)
        questions.Add(new QuizQuestion
        {
            question = "10. เป้าหมาย ในการดำเนินธุรกิจของสหกรณ์ คือ",
            choices = new string[] { 
            "ลดรายจ่าย เพิ่มรายได้ให้สมาชิก", 
            "เพิ่มเงินกู้ให้สมาชิกมาก ๆ", 
            "แสวงหากำไรให้มากที่สุด", 
            "ข้อ ก. และ ข. ถูก" 
            },
            correctAnswerIndex = 0 // ก.ลดรายจ่าย เพิ่มรายได้ให้สมาชิก
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
            correctAnswerIndex = 0 // ก.
        });

    */
    
    }

    void DisplayQuestion(int index)
    {
        if (index < 0 || index >= questions.Count) return;

        QuizQuestion q = questions[index];
    }
}
