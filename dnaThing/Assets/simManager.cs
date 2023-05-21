using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class simManager : MonoBehaviour
{
    public GameObject dna;
    public playerCam playerCam;
    public GameObject inputUI;
    public TMP_InputField inputField;
    public TextMeshProUGUI errorText;

    void Awake()
    {
        errorText.text = "";
    }

    public void StartSim()
    {
        errorText.text = "";
        string[] codons = {
            "TAA",
            "TAG",
            "TGA"
            };
        if(inputField.text.Length < 6)
        {
            // Check for length
            errorText.text = "Error: string is too short.";
            return;
        } else if (Array.IndexOf(codons, inputField.text.Substring(inputField.text.Length - 4, 3)) == -1
            && Array.IndexOf(codons, inputField.text.Substring(inputField.text.Length - 5, 3)) == -1)
        {
            //Check stop codons for string 1 & 2
            errorText.text = "Error: neither string has a valid stop codon.";
            return;
        }

        //check for base pairs
        for (int i = 0; i < inputField.text.Length; i+=2)
        {
            string pair = inputField.text[i].ToString() + inputField.text[i + 2].ToString();
            Debug.Log(pair);

            if (pair != "AG" && pair!= "GA" && pair != "CT" && pair != "TC")
            {
                errorText.text = "Error: one of the base pairings is invalid.";
                return;
            }
        }


        Instantiate(dna).GetComponent<dna>().codeIdk = inputField.text;
        playerCam.enableMove = true;
        inputUI.SetActive(false);
    }
}
