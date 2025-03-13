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

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
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
