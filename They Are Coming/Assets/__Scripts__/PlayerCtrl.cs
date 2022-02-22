using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 5f;

    public GameObject player;

    public GameObject PlayerHolder;

    public int playerCount;

    public float leftBound = -4.0f;

    public float rightBound = 4.0f;

    public GameObject SpawnPos;

    void Start()
    {

    }
    
    void Update()
    {
        PlayerMovement();
        CantMoveOutOfBounds();
    }

    void PlayerMovement()
    {
        if (GameManager.Instance.isGameActive == true)
        {
            //Player move back
            transform.Translate(Vector3.back * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * 10 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * 10 * Time.deltaTime);
            }

        }
    }

    void CantMoveOutOfBounds()
    {
        if(transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("+15"))
        {
            StartCoroutine(_15PlayerSpawn());

            Debug.Log("+15");
        }

        if (other.gameObject.CompareTag("+10"))
        {
            StartCoroutine(_10PlayerSpawn());
            Debug.Log("+10");
        }

        if(other.gameObject.CompareTag("Increase Player"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("increase");
        }
    }

    IEnumerator _10PlayerSpawn()
    {
        
        for(int i = 0; i < 10; i++)
        {
            Vector3 spawnLocation = new Vector3(PlayerHolder.transform.position.x, PlayerHolder.transform.position.y, PlayerHolder.transform.position.z - 1) + 
                                    new Vector3(Random.onUnitSphere.x * Random.Range(-1.5f, 1.5f), 1, Random.onUnitSphere.z * Random.Range(-1.5f, 1.5f));

            GameObject playerClone = Instantiate(player,spawnLocation, PlayerHolder.transform.rotation);

            playerClone.transform.SetParent(PlayerHolder.transform);

            yield return new WaitForSeconds(0.1f);

            playerCount += 1;
        }
    }

    IEnumerator _15PlayerSpawn()
    {

        for (int i = 0; i < 15; i++)
        {
            Vector3 spawnLocation = new Vector3(PlayerHolder.transform.position.x, PlayerHolder.transform.position.y, PlayerHolder.transform.position.z - 1) +
                                    new Vector3(Random.onUnitSphere.x * Random.Range(-1.5f, 1.5f), 1, Random.onUnitSphere.z * Random.Range(-1.5f, 1.5f));

            GameObject playerClone = Instantiate(player, spawnLocation, PlayerHolder.transform.rotation);

            playerClone.transform.SetParent(PlayerHolder.transform);

            yield return new WaitForSeconds(0.1f);

            playerCount += 1;
        }
    }
}
