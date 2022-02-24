using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    public Vector3 offset2;
    void Start()
    {
        offset2 = new Vector3(0, 0, -10f);
    }

    
    void Update()
    {
        if(PlayerCtrl.Instance.sort == false)
        {
            camFollowPlayer();
        }

        if (PlayerCtrl.Instance.sort == true)
        {
            camFinishPoint();
        }
    }

    public void camFinishPoint()
    {
        Vector3 desiredPosition = new Vector3(0, target.position.y + offset.y, target.position.z + offset2.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }

    public void camFollowPlayer()
    {
        Vector3 desiredPosition = new Vector3(0, target.position.y + offset.y, target.position.z + offset.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

    }
}
