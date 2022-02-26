using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public static BulletFire Instance;

    public GameObject bulletPrefabs;

    public GameObject PointFire;

    public float timeStamp;

    public float timeDelay;


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        timeDelay = 2f;
    }

    
    void Update()
    {
        StartCoroutine(spawnBullet());
        spawnBullet();

        if(PlayerCtrl.Instance.sort == true)
        {
            timeDelay = 0.5f;
        }

        if (PlayerCtrl.Instance.sortMap2 == true)
        {
            timeDelay = 0.5f;
        }
    }

    
    
    IEnumerator spawnBullet()
    {
        if(GameManager.Instance.isGameActive == true)
        {
            yield return new WaitForSeconds(1f);
            if (Time.time > timeStamp)
            {
                Instantiate(bulletPrefabs, PointFire.transform.position, Quaternion.identity);

                timeStamp = Time.time + timeDelay;

                yield return new WaitForSeconds(1f);
                
            }
        }
    }
}
