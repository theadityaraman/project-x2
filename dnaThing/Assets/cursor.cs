using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    public Camera cam;
    public float distanceFromCamera = 2f;
    public float sensitivity = 1f;
    public LayerMask layerMask;

    public Material highlightMat;
    private Material tempMat;
    private GameObject previousHitObject;

    void Update()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera);
        Vector3 worldPosition = cam.ScreenToWorldPoint(mousePosition);

        // Adjust the cursor's position based on the camera's position and mouse input
        Vector3 targetPosition = cam.transform.position + (worldPosition - cam.transform.position) * sensitivity;
        transform.position = targetPosition;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);

            if (previousHitObject != hit.collider.gameObject)
            {
                ResetMaterial();
                tempMat = hit.collider.gameObject.GetComponent<MeshRenderer>().material;
                hit.collider.gameObject.GetComponent<MeshRenderer>().material = highlightMat;
                previousHitObject = hit.collider.gameObject;
            }
        }
        else
        {
            ResetMaterial();
            // If no hit, draw a raycast with a default length
            Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);
        }
        if(Input.GetMouseButtonDown(0) && hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject);
        }
    }

    private void ResetMaterial()
    {
        if (previousHitObject != null)
        {
            MeshRenderer meshRenderer = previousHitObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.material = tempMat;
            }
            previousHitObject = null;
        }
    }
}
