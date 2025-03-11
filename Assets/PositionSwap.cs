using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSwap : MonoBehaviour
{
    public PositionCheck parentObj;
    public Vector3 offset;
    public float snapDistance = 5f; // Distance required for snapping

    private bool isDragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Start dragging
        {
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0)) // Stop dragging and check for snap
        {
            isDragging = false;
            TrySnapToPosition();
        }

        if (isDragging)
        {
            DragObject();
        }
    }

    void TrySnapToPosition()
    {
        float distance = Vector3.Distance(transform.position, parentObj.pos);
        if (distance <= snapDistance)
        {
            transform.position = parentObj.pos + offset;
        }
    }

    void DragObject()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z; // Maintain depth
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
