using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    void Start()
    {

    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        detectPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boost Speed")
        {

            Debug.Log("SpeedBoost");
        }
    }

    void detectPlayer()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 5f);

        foreach(Collider hit in hits)
        {
            if(hit.transform == null)
            {
                return;
            }

            if(hit.tag == "Player")
            {
                float step = 0.05f * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").GetComponent<Transform>().position, step);

                transform.LookAt(GameObject.Find("Player").GetComponent<Transform>().position);
            }
        }
    }
}
