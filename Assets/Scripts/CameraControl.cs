using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(transform.position.x - target.position.x,
            transform.position.y - target.position.y,
            transform.position.z - target.position.z);
    }

    void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
}
