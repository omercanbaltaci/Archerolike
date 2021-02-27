using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    public Transform player;
    private float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        yOffset = transform.position.z - player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        newPosition.z = player.position.z + yOffset;
        transform.position = newPosition;
    }
}
