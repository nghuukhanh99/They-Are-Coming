using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public static SpawnEnemy Instance;

    public GameObject EnemyPrefabs;

    public List<GameObject> listEnemy = new List<GameObject>();

    public float timeStamp;

    public int enemyCount;

    public int enemyCount2;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        enemyCount = 0;
    }

    
    void Update()
    {
        spawnTheEnemy();

        if(PlayerCtrl.Instance.isRotate == true)
        {
            spawnTheEnemyMap2();
        }
    }

    void spawnTheEnemy()
    {
        if(GameManager.Instance.isGameActive == true)
        {
            if (Time.time > timeStamp)
            {
                if (enemyCount >= 60)
                {
                    return;
                }

                GameObject Enemy = Instantiate(EnemyPrefabs, new Vector3(Random.Range(-4, 4), 1, 60), Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)));

                listEnemy.Add(Enemy);

                timeStamp = Time.time + 0.15f;

                enemyCount += 1;
            }
        }
    }

    void spawnTheEnemyMap2()
    {
        if (GameManager.Instance.isGameActive == true)
        {
            if (Time.time > timeStamp)
            {
                if (enemyCount2 >= 60)
                {
                    return;
                }

                GameObject Enemy = Instantiate(EnemyPrefabs, new Vector3(-19.5f, 1f, Random.Range(-76f, -84f)), Quaternion.Euler(new Vector3(transform.rotation.x, 90f, transform.rotation.z)));

                listEnemy.Add(Enemy);

                timeStamp = Time.time + 0.15f;

                enemyCount2 += 1;
            }
        }
    }
}
