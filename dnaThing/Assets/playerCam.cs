using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCam : MonoBehaviour
{
    public bool enableMove = false;
    public float scale = 0.02f;
    public int maxSize = 7;
    public float moveSpeed = 0.3f;

    void Update()
    {
        if (enableMove)
        {
            // Adjust camera position based on mouse input
            this.GetComponent<Camera>().orthographicSize =
                Mathf.Clamp(
                    this.GetComponent<Camera>().orthographicSize-Input.mouseScrollDelta.y * scale,
                    0.1f,
                    maxSize);
            //this.transform.position += this.transform.forward * Input.mouseScrollDelta.y * scale;
            this.transform.position += this.transform.right * (Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0) * moveSpeed;
            this.transform.position += this.transform.up * (Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0) * moveSpeed;
        }
    }
}
