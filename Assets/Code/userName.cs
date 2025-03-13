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

    public void OnConfirm()
    {
        string firstName = firstNameInput.text.Trim();
        string lastName = lastNameInput.text.Trim();

        if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
        {
            PlayerPrefs.SetString("FirstName", firstName);
            PlayerPrefs.SetString("LastName", lastName);
            PlayerPrefs.Save();

            SceneManager.LoadScene("gamePlay");
        }
        else
        {
            Debug.Log("กรุณากรอกชื่อและนามสกุลให้ครบ");
        }
    }

    public void OnCancel()
    {
        firstNameInput.text = "";
        lastNameInput.text = "";
    }
}
