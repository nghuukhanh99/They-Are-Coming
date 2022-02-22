using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public float speed;

    public float stoppingDistance;

    public float retreatDistance;

    public Transform Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {


        transform.LookAt(Player.transform);

        // Enemy follow multiplayer with tag
        if (Vector3.Distance(transform.position, Player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, 5f * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, Player.position) < stoppingDistance && Vector3.Distance(transform.position, Player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, Player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, -0.5f * Time.deltaTime);
        }
    }
}
