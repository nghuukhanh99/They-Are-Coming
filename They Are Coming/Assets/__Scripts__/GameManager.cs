using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameActive = false;

    public Button startButton;

    public Button restartButton;

    public bool Map2Active;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 0;

        
    }

    
    void Update()
    {
        StartCoroutine(checkNextLevel());
    }

    public void StartGameButton()
    {
        startButton.gameObject.SetActive(false);

        new WaitForSeconds(2f);

        isGameActive = true;

        Time.timeScale = 1;

        PlayerCtrl.Instance.joystick.gameObject.SetActive(true);
    }

    public void RestartGameButton()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator checkNextLevel()
    {
        if(SpawnEnemy.Instance.listEnemy.Count == 0 && PlayerCtrl.Instance.sort == true)
        {
            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene(1);

            Map2Active = true;

            Debug.Log("NextLevel");
        }

        if (SpawnEnemy.Instance.listEnemy.Count == 0 && PlayerCtrl.Instance.sortMap2 == true)
        {
            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene(1);

            Debug.Log("NextLevel");
        }
    }

    
}
