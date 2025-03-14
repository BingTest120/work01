using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileKeyboardSupport : MonoBehaviour, IPointerDownHandler
{
    public TMP_InputField firstNameInput;
    public TMP_InputField lastNameInput;
    private TouchScreenKeyboard keyboard;

    private void Start()
    {
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

    public void OnPointerDown(PointerEventData eventData)
    {
        if (EventSystem.current.currentSelectedGameObject == firstNameInput.gameObject)
        {
            OpenKeyboard(firstNameInput.text);
        }
        else if (EventSystem.current.currentSelectedGameObject == lastNameInput.gameObject)
        {
            OpenKeyboard(lastNameInput.text);
        }
    }
}
