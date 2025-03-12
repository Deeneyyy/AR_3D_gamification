using UnityEngine;

public class SnapManager : MonoBehaviour
{
    public Transform objectA;
    public Transform objectB;
    public float snapThreshold = 2.0f; // Try increasing if not snapping

    public void CheckSnap()
    {
        if (objectA == null || objectB == null)
        {
            Debug.LogError("SnapManager: One of the objects is missing!");
            return;
        }

        float distance = Vector3.Distance(objectA.position, objectB.position);
        Debug.Log("Checking snap distance: " + distance);

        if (distance < snapThreshold)
        {
            Debug.Log("Objects are close enough to snap!");
            SnapObjects();
        }
    }

    private void SnapObjects()
    {
        objectA.position = objectB.position;
        Debug.Log("Objects snapped together at: " + objectA.position);
    }
}
