using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropV1 : MonoBehaviour
{
    Vector3 offset;
    public string correctDropTag; // Assign in Inspector (e.g., "RedDrop" for red object)
    private float fixedY; // Stores the original Y position

    void Start()
    {
        fixedY = transform.position.y; // Store initial Y position
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        offset.y = 0; // No Y offset
        GetComponent<Collider>().enabled = false;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = MouseWorldPosition();

        // Move in X and Z only, keeping Y locked
        transform.position = new Vector3(mousePosition.x + offset.x, fixedY, mousePosition.z + offset.z);
    }

    void OnMouseUp()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            // Snap only in X and Z, keeping Y fixed
            transform.position = new Vector3(hitInfo.transform.position.x, fixedY, hitInfo.transform.position.z);

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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, fixedY, 0)); // Plane at fixed Y position
        float distance;

        if (groundPlane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance); // Get correct XZ world position
        }
        return transform.position;
    }
}
