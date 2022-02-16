using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 5f;

    public Rigidbody rb;

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
        if (other.gameObject.CompareTag("X2"))
        {
            

            Debug.Log("x2");
        }

        if (other.gameObject.CompareTag("+10"))
        {
            StartCoroutine(_10PlayerSpawn());
            Debug.Log("+10");
        }
    }

    IEnumerator _10PlayerSpawn()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject playerClone = Instantiate(player, PlayerHolder.transform.position + new Vector3(Random.insideUnitSphere.x * 2, 1, Random.insideUnitSphere.z * 2),
                                                 PlayerHolder.transform.rotation);

            playerClone.transform.SetParent(PlayerHolder.transform);

            yield return new WaitForSeconds(0.1f);

            playerCount += 1;
        }
    }
}
