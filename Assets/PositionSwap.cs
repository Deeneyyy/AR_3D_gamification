using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSwap : MonoBehaviour
{
    public PositionCheck parentObj;  // Reference to PositionCheck
    public Vector3 offset;           // Offset applied to the position
    public float activationRadius = 5f; // The required distance for snapping

    void Update()
    {
        if (Input.GetMouseButtonUp(0)) // Snap only on mouse release
        {
            TrySnapToPosition();
        }
    }

    void TrySnapToPosition()
    {
        float distance = Vector3.Distance(transform.position, parentObj.pos);

        if (distance <= activationRadius) // Snap only if within range
        {
            this.transform.position = parentObj.pos + offset;
        }
    }
}
