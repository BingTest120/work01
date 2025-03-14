using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardSupport : MonoBehaviour
{
    void Start()
    {
        if (TouchScreenKeyboard.isSupported)
        {
            TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        }
    }
}
