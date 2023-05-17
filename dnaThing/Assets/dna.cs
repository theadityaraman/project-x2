using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dna : MonoBehaviour
{
    public GameObject pair;
    public int noPairs = 4;
    public float rotation = 10;
    public float offset = 1f;
    public GameObject[] pairs;

    void Start()
    {
        pairs = new GameObject[noPairs]; // Initialize the array with the appropriate size

        for (int i = 0; i < noPairs; i++)
        {
            pairs[i] = Instantiate(pair, new Vector3(0, i * offset, 0), Quaternion.Euler(0, rotation * i, 0));
        }
    }
}
