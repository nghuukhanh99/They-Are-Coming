using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyPrefabs;

    //public List<Transform> spawnPos = new List<Transform>();

    public float timeStamp;

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
                Instantiate(EnemyPrefabs, /*spawnPos[Random.Range(0, spawnPos.Count)].position*/ new Vector3(Random.Range(-4, 4), 1, 65)
                    , Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z)));

                timeStamp = Time.time + 0.1f;
            }
        }
    }
}
