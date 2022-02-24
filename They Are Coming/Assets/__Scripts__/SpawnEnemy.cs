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
     
    }

    

    void spawnTheEnemy()
    {
        if(GameManager.Instance.isGameActive == true)
        {
            if (Time.time > timeStamp)
            {
                    if (enemyCount >= 100)
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
}
