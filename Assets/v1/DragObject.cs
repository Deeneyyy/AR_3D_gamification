using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;
    private float zDistance;
    private bool isDragging = false;

    void OnMouseDown()
    {
        zDistance = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
        Debug.Log(gameObject.name + " grabbed!");
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
            Debug.Log(gameObject.name + " moving to " + transform.position);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        Debug.Log(gameObject.name + " released!");
        // Check if it should snap after dragging
        FindObjectOfType<SnapManager>().CheckSnap();
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zDistance; // Maintain depth
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
