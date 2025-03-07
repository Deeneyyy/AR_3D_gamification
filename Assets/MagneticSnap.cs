using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticSnap : MonoBehaviour
{
    public float snapRange = 0.2f; // How close it must be to snap
    public List<Transform> snapPoints = new List<Transform>(); // Snap points exposed in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnapPoint"))
        {
            Transform closestSnapPoint = FindClosestSnapPoint(other.transform);
            if (closestSnapPoint != null)
            {
                float distance = Vector3.Distance(closestSnapPoint.position, other.transform.position);
                if (distance < snapRange)
                {
                    transform.position = other.transform.position; // Snap position
                    transform.rotation = other.transform.rotation; // Align rotation
                }
            }
        }
    }

    private Transform FindClosestSnapPoint(Transform target)
    {
        Transform closest = null;
        float closestDistance = float.MaxValue;

        foreach (Transform snapPoint in snapPoints)
        {
            float distance = Vector3.Distance(snapPoint.position, target.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = snapPoint;
            }
        }

        return closest;
    }
}
