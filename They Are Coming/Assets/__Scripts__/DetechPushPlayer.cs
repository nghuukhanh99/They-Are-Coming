using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetechPushPlayer : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        
    }


    void Update()
    {
        rb.velocity = Vector3.zero;
    }
}
