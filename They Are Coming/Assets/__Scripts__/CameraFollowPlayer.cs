using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 desiredPosition = new Vector3(0, target.position.y + offset.y, target.position.z + offset.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        
    }
}
