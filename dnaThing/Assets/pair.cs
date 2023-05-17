using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pair : MonoBehaviour
{
    public GameObject bond, bp1, bp2;
    public void instOb()
    {
        float dist = bond.GetComponent<Transform>().localScale.y;
        float width = (bp1.GetComponent<Transform>().localScale.x + dist) / 2;
        GameObject BP1 = Instantiate(bp1, Vector3.zero, Quaternion.identity, transform);
        BP1.transform.localPosition = new Vector3(-width, 0, 0);

        width = (bp2.GetComponent<Transform>().localScale.x + dist) / 2;
        GameObject BP2 = Instantiate(bp2, Vector3.zero, Quaternion.identity, transform);
        BP2.transform.localPosition = new Vector3(width, 0, 0);

        Debug.Log(Vector3.Distance(BP2.transform.position, BP1.transform.position));
    }


    //0.765 != (0.53 + 0.34) / 2
    //should .435

}
