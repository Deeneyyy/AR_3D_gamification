using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    Vector3 offset;
    public string correctDropTag; // Assign this in the Inspector (e.g., "RedDrop" for red object)

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        GetComponent<Collider>().enabled = false;
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            // Snap to any drop area
            transform.position = hitInfo.transform.position;

            // Check if dropped onto the correct area
            if (hitInfo.transform.CompareTag(correctDropTag))
            {
                Debug.Log(gameObject.name + " is on the correct area! ✅");
            }
            else
            {
                Debug.Log(gameObject.name + " is on the WRONG area! ❌");
            }
        }
        GetComponent<Collider>().enabled = true;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}