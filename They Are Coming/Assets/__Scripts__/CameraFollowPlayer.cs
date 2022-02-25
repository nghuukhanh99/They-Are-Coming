using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    public Vector3 offset2;

    public Vector3 offset3;
    void Start()
    {
        offset2 = new Vector3(0, 0, -10f);
    }


    void Update()
    {
        if (PlayerCtrl.Instance.normalCamera == true)
        {
            camFollowPlayer();
        }

        if (PlayerCtrl.Instance.sortCamera == true)
        {
            camFinishPoint();
        }

        if(PlayerCtrl.Instance.lockPosZ == true)
        {
            PlayerCtrl.Instance.normalCamera = false;

            PlayerCtrl.Instance.sortCamera = false;

            camFollowPlayerIfTurn();
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

    public void camFollowPlayerIfTurn()
    {
        transform.rotation = Quaternion.Euler(new Vector3(59f, -90f, 0));

        Vector3 desiredPosition = new Vector3(target.position.x + offset3.x, target.position.y + offset.y, -80f);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        
    }
}