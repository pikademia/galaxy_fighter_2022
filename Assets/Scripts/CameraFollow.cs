using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    Vector3 offset;
    Vector3 newPos;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if(target != null)
        {
            offset = transform.position - target.position;

        }
    }

    private void LateUpdate()
    {
        MoveX();
    }

    void MoveX()
    {
        if(target!=null && target.position.x > -6f)
        {
            newPos = new Vector3(target.position.x + offset.x, transform.position.y + offset.y, transform.position.z);
            transform.position = newPos;
        }
    }

}
