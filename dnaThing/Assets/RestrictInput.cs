using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class RestrictInput : MonoBehaviour
{
    public List<char> acceptedCharacters;

    private TMP_InputField inputField;

    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onValidateInput += ValidateInput;
    }

    private char ValidateInput(string text, int charIndex, char addedChar)
    {
        // Check if the added character is in the accepted characters list
        if (acceptedCharacters.Contains(addedChar))
        {
            return addedChar; // Accept the character
        }

        // Reject the character
        return '\0'; // Returning '\0' effectively cancels the input
    }
}
