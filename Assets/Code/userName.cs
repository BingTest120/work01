using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class userName : MonoBehaviour
{
    public TMP_InputField firstNameInput;
    public TMP_InputField lastNameInput;
    private SoundManager soundManager;
    private TouchScreenKeyboard keyboard;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();

        // เชื่อมโยงกับ onSelect listener เพื่อเปิดคีย์บอร์ด
        firstNameInput.onSelect.AddListener(OpenKeyboard);
        lastNameInput.onSelect.AddListener(OpenKeyboard);
    }

    private void OpenKeyboard(string text)
    {
        if (TouchScreenKeyboard.isSupported) 
        {
            keyboard = TouchScreenKeyboard.Open(text, TouchScreenKeyboardType.Default);
        }
    }

    void Update()
    {
        if (keyboard != null && keyboard.active)
        {
            if (firstNameInput.isFocused)
            {
                firstNameInput.text = keyboard.text; 
            }
            else if (lastNameInput.isFocused)
            {
                lastNameInput.text = keyboard.text;
            }
        }
    }

    public void OnConfirm()
    {
        string firstName = firstNameInput.text.Trim();
        string lastName = lastNameInput.text.Trim();

        if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
        {
            PlayerPrefs.SetString("FirstName", firstName);
            PlayerPrefs.SetString("LastName", lastName);
            PlayerPrefs.Save();
            
            soundManager.soundQuizResul();
            Invoke("LoadScene", 0.5f);
        }
        else
        {
            soundManager.soundCancel();
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("gamePlay");
    }

    public void OnCancel()
    {
        soundManager.soundCancel();
        
        firstNameInput.text = "";
        lastNameInput.text = "";
    }
}
