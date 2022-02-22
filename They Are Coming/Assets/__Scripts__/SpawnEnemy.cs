using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public static SpawnEnemy Instance;

    public GameObject EnemyPrefabs;

    public List<GameObject> listEnemy = new List<GameObject>();



    //public List<Transform> spawnPos = new List<Transform>();

    public float timeStamp;

    
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
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
               GameObject Enemy = Instantiate(EnemyPrefabs, new Vector3(Random.Range(-4, 4), 1, 60), Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)));

                listEnemy.Add(Enemy);

                timeStamp = Time.time + 0.2f;
            }
        }
    }
}
