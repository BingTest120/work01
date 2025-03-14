using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileKeyboardSupport : MonoBehaviour, IPointerClickHandler
{
    public TMP_InputField firstNameInput;
    public TMP_InputField lastNameInput;

    void Start()
    {
        if (firstNameInput == null)
        {
            firstNameInput = GetComponent<TMP_InputField>();
        }
        if (lastNameInput == null)
        {
            lastNameInput = GetComponent<TMP_InputField>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
            if (eventData.selectedObject == firstNameInput.gameObject)
            {
                firstNameInput.DeactivateInputField();
                firstNameInput.ActivateInputField();
            }
            else if (eventData.selectedObject == lastNameInput.gameObject)
            {
                lastNameInput.DeactivateInputField();
                lastNameInput.ActivateInputField();
            }
        #endif
    }
}
