using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameActive = false;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        StartCoroutine(StartGameDelay());
        
    }

    
    void Update()
    {
        
    }

    IEnumerator StartGameDelay()
    {
        yield return new WaitForSeconds(2f);

        isGameActive = true;
    }
}
