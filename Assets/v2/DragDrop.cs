using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 startPosition; // Store the original position
    public string correctDestinationTag; // Assign the correct drop area tag in the Inspector

    void Start()
    {
        startPosition = transform.position; // Save the initial position
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
        GetComponent<Collider>().enabled = false;
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        GetComponent<Collider>().enabled = true;

        var rayOrigin = Camera.main.transform.position;
        var rayDirection = GetMouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            // Check if the cube is placed in the correct region
            if (hitInfo.transform.CompareTag(correctDestinationTag))
            {
                transform.position = hitInfo.transform.position; // Snap to the correct area
            }
            else
            {
                transform.position = startPosition; // Return to original position if incorrect
            }
        }
        else
        {
            transform.position = startPosition; // Return to original position if no valid drop
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
