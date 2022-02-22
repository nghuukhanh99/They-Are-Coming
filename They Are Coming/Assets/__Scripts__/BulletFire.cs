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
        StartCoroutine(spawnBullet());
        spawnBullet();
    }

    
    IEnumerator spawnBullet()
    {
        if(GameManager.Instance.isGameActive == true)
        {
            yield return new WaitForSeconds(1f);
            if (Time.time > timeStamp)
            {
                Instantiate(bulletPrefabs, PointFire.transform.position, Quaternion.identity);

                timeStamp = Time.time + 3f;

                yield return new WaitForSeconds(1f);
                
            }
        }
    }
}
