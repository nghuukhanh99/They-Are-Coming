using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;

    public Rigidbody rb;

    public GameObject PlayerPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, PlayerPos.transform.position, speed * Time.fixedDeltaTime);

        rb.MovePosition(pos);

    }
}
