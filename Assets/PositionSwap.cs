using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PositionSwap : MonoBehaviour
{
    public PositionCheck parentObj;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //print(parentObj.pos);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = parentObj.pos + offset;
    }
}
