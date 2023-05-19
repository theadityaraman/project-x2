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

    public void StartSim()
    {
        Instantiate(dna).GetComponent<dna>().codeIdk = inputField.text;
        playerCam.enableMove = true;
        inputUI.SetActive(false);
    }
}
