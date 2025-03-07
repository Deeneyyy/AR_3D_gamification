using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCheck : MonoBehaviour
{
    public GameObject parentObj;
    public GameObject childObj;
    public Vector3 pos;
    private void Start()
    {
        childObj = this.gameObject;
    }
    void Update()
    {
        pos = parentObj.transform.position + childObj.transform.localPosition;
        //print(pos);
    }
}