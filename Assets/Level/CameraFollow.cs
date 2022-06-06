using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject target;
    Transform targetT;
    Vector3 offset;
    Vector3 newPos;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if(target != null)
        {
            targetT = target.transform;
            offset = transform.position - targetT.position;
        }
    }

    private void LateUpdate()
    {
        MoveX();
    }

    void MoveX()
    {
        if(target!=null && targetT.position.x > -6f)
        {
            newPos = new Vector3(targetT.position.x + offset.x, transform.position.y + offset.y, transform.position.z);
            transform.position = newPos;
        }
    }

}
