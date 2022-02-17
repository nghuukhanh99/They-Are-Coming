using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public GameObject bulletPrefabs;

    public GameObject PointFire;

    public float timeStamp;

    void Start()
    {
        
    }

    
    void Update()
    {
        spawnBullet();
    }

    void spawnBullet()
    {
        if (Time.time > timeStamp)
        {
            Instantiate(bulletPrefabs, PointFire.transform.position, Quaternion.identity);

            timeStamp = Time.time + 1.2f;
        }
    }
}
