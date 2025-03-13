using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public AudioSource bgSource; 
    [SerializeField] public AudioSource sfxSource; 
    [SerializeField] public AudioClip bgSound;
    [SerializeField] public AudioClip buttonSound, quizResulSound, clickSound, cancelSound; 

    [SerializeField] GameObject SoundOnIcon;  // ไอคอนเสียงเปิด
    [SerializeField] GameObject SoundOffIcon; // ไอคอนเสียงปิด

    private bool soundMuted = false; // ตัวแปรเก็บสถานะเปิด/ปิดเสียง

    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // อย่าลบ GameObject นี้เมื่อโหลดฉากใหม่
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bgSource.clip = bgSound;
        bgSource.Play();
        
        LoadSound(); // โหลดค่าการตั้งค่าเสียง
        UpdateButtonSound(); // อัพเดทปุ่มเสียง
    }

    public void OnButtonSound() // เมื่อกดปุ่มเสียง
    {
        soundMuted = !soundMuted; // สลับสถานะของเสียง
        bgSource.mute = soundMuted;  // ปิด/เปิดเสียงพื้นหลัง
        sfxSource.mute = soundMuted; // ปิด/เปิดเสียง SFX
        SaveSound(); // บันทึกการตั้งค่าเสียง
        UpdateButtonSound(); // อัพเดทปุ่มเสียง
    }

    private void UpdateButtonSound() // อัพเดทการแสดงผลปุ่มเสียง
    {
        if (soundMuted)
        {
            SoundOnIcon.SetActive(false); // ซ่อนไอคอนเสียงเปิด
            SoundOffIcon.SetActive(true); // แสดงไอคอนเสียงปิด
        }
        else
        {
            SoundOnIcon.SetActive(true); // แสดงไอคอนเสียงเปิด
            SoundOffIcon.SetActive(false); // ซ่อนไอคอนเสียงปิด
        }
    }

    private void LoadSound() // โหลดค่าการตั้งค่าเสียงจาก PlayerPrefs
    {
        soundMuted = PlayerPrefs.GetInt("soundMuted", 0) == 1; // อ่านค่าจาก PlayerPrefs
        bgSource.mute = soundMuted;  // ตั้งค่า mute ของ bgSource
        sfxSource.mute = soundMuted; // ตั้งค่า mute ของ sfxSource
    }

    private void SaveSound() // บันทึกค่าการตั้งค่าเสียงลงใน PlayerPrefs
    {
        PlayerPrefs.SetInt("soundMuted", soundMuted ? 1 : 0); // บันทึกสถานะเสียง
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void soundButton()
    {
        PlaySFX(buttonSound);  
    }

    public void soundQuizResul()
    {
        PlaySFX(quizResulSound);  
    }

    public void soundClick()
    {
        PlaySFX(clickSound);  
    }

    public void soundCancel()
    {
        PlaySFX(cancelSound);  
    }
}
