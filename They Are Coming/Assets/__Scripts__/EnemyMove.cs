using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public float speed;

    public Rigidbody rb;

    protected NavMeshAgent Enemy;

    public Transform PlayerPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Enemy = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        //rb.velocity = Vector3.forward * speed * Time.deltaTime;
        Enemy.SetDestination(PlayerPos.position);
    }
}
