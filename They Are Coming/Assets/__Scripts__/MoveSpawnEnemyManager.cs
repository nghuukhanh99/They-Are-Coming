using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpawnEnemyManager : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(GameManager.Instance.isGameActive == true)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}
