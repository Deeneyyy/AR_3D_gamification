using UnityEngine;
using System.Collections.Generic;

public class SnapManager1 : MonoBehaviour
{
    public List<Transform> mainSnapPoints;  // Snap points on the main object
    public float snapThreshold = 1.5f;      // Distance to snap

    public void CheckSnap(GameObject draggedObject, Transform objectSnapPoint)
    {
        Transform bestSnapPoint = null;
        float closestDistance = Mathf.Infinity;

        // Find the nearest snap point on the main object
        foreach (Transform mainPoint in mainSnapPoints)
        {
            float distance = Vector3.Distance(objectSnapPoint.position, mainPoint.position);
            if (distance < snapThreshold && distance < closestDistance)
            {
                closestDistance = distance;
                bestSnapPoint = mainPoint;
            }
        }

        // Snap if a valid snap point is found
        if (bestSnapPoint != null)
        {
            draggedObject.transform.position = bestSnapPoint.position;
            Debug.Log(draggedObject.name + " snapped to " + bestSnapPoint.name);
        }
    }
}
