using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DNAPair
{
    public char character;
    public GameObject gameObject;
}

public class dna : MonoBehaviour
{
    public string codeIdk = "CCCCCCCCAAAAAAAAAAAAAAAAAAAAAAAAAAAAUUUUUUUUUUUUUUUUUUUGGGGGGUUUUUUUUUUUUCCCCCC";
    public DNAPair[] dnaPairs;
    public GameObject pairPrefab;
    public float rotationOffset = 13f;
    public float rotationSpeed = 10f;
    public float offset = 1f;

    private GameObject[] pairs;

    private void Start()
    {
        pairs = new GameObject[codeIdk.Length / 2]; // Initialize the array with the appropriate size

        for (int i = 0; i < codeIdk.Length - 1; i += 2)
        {
            GameObject obj1 = GetGameObjectForCharacter(codeIdk[i]);
            GameObject obj2 = GetGameObjectForCharacter(codeIdk[i + 1]);

            if (obj1 != null && obj2 != null)
            {
                int pairIndex = i / 2;
                pairs[pairIndex] = Instantiate(pairPrefab, new Vector3(0, pairIndex * offset, 0), Quaternion.Euler(0, rotationOffset * pairIndex, 0));
                pairs[pairIndex].GetComponent<pair>().bp1 = obj1;
                pairs[pairIndex].GetComponent<pair>().bp2 = obj2;
                pairs[pairIndex].GetComponent<pair>().instOb();
                pairs[pairIndex].transform.parent = transform;
            }
            else
            {
                Debug.Log(codeIdk[i]);
                Debug.Log(codeIdk[i + 1]);
            }
        }

    }

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private GameObject GetGameObjectForCharacter(char character)
    {
        foreach (var pair in dnaPairs)
        {
            if (pair.character == character)
                return pair.gameObject;
        }

        Debug.LogError("No corresponding GameObject found for character: " + character);
        return null;
    }
}
