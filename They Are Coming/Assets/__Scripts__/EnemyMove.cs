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
        // Enemy follow multiplayer with tag


        transform.LookAt(Player.transform);
        if (Vector3.Distance(transform.position, Player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }
        else if(Vector3.Distance(transform.position, Player.position) < stoppingDistance && Vector3.Distance(transform.position, Player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector3.Distance(transform.position, Player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }
    }
}
