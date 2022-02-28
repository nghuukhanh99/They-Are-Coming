using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using EasyJoystick;

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl Instance;

    public Joystick joystick;

    public float speed = 5f;

    public GameObject player;

    public GameObject PlayerCurrent;

    public GameObject PlayerHolder;

    public int playerCount;

    public float leftBound = -4.0f;

    public float rightBound = 4.0f;

    public GameObject SpawnPos;

    public List<GameObject> PlayerList = new List<GameObject>();

    public List<Vector3> PosSortPlayer = new List<Vector3>();

    public List<Vector3> PosSortPlayerMap2 = new List<Vector3>();

    public Rigidbody rb;

    public bool sort;

    public bool lockPosX = true;

    public bool lockPosZ = false;

    public GameObject RotatePos;

    public bool sortCamera;

    public bool normalCamera;

    public bool sortMap2;

    public bool sortCameraMap2;

    public bool isRotate;

    public bool moveX;
    private void Awake()
    {
        Instance = this;

        joystick.gameObject.SetActive(false);
    }

    void Start()
    {
        sort = false;

        sortMap2 = false;

        sortCamera = false;

        sortCameraMap2 = false;

        normalCamera = true;

        PlayerList.Add(PlayerCurrent);

        isRotate = false;

        moveX = true;
    }
    
    void Update()
    {
        PlayerMovement();

        CantMoveOutOfBounds();
        
        sortPlayer();
    }

    void rotationPlayer()
    {
        PlayerHolder.transform.Rotate(new Vector3(transform.rotation.x, -90f, transform.rotation.z));
    }

    void PlayerMovement()
    {
        if (GameManager.Instance.isGameActive == true)
        {
            if(sort == false)
            {
                if(sortCameraMap2 == false)
                {
                    float xInput = joystick.Horizontal();

                    float zInput = joystick.Vertical();

                    Vector3 moveDirectionX = new Vector3(xInput, 0f, 0f);

                    Vector3 moveDirectionZ = new Vector3(0, 0f, zInput);

                    moveDirectionX.Normalize();

                    //Player move back
                    transform.Translate(Vector3.back * speed * Time.deltaTime);


                    if(sort == true)
                    {
                        transform.Translate(moveDirectionX * 15 * Time.deltaTime, Space.World);
                    }
                    
                    if(GameManager.Instance.Map2Active == true)
                    {
                        if(moveX == true)
                        {
                            transform.Translate(moveDirectionX * 15 * Time.deltaTime, Space.World);
                        }
                        
                        if(isRotate == true)
                        {
                            moveX = false;
                            transform.Translate(moveDirectionZ * 15 * Time.deltaTime, Space.World);
                        }
                        
                    }
                }
            }
            
        }
    }

    void CantMoveOutOfBounds()
    {
        if(lockPosX == true)
        {
            if (transform.position.x < leftBound)
            {
                transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
            }
            if (transform.position.x > rightBound)
            {
                transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
            }
        }

        if(lockPosZ == true)
        {
            if(transform.position.z < -83f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -83f);
            }
            if(transform.position.z > -77f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -77f);
            }
        }
        
    }

    void sortPlayer()
    {
        if(PlayerList != null)
        {
            if(sort == true)
            {
                for (int i = 0; i < PlayerList.Count; i++)
                {
                    PlayerList[i].transform.position = Vector3.MoveTowards(PlayerList[i].transform.position, PosSortPlayer[i], speed * Time.deltaTime);
                    PlayerList[i].GetComponent<Rigidbody>().isKinematic = true;
                }
            }

            if(sortMap2 == true)
            {
                for (int i = 0; i < PlayerList.Count; i++)
                {
                    PlayerList[i].transform.position = Vector3.MoveTowards(PlayerList[i].transform.position, PosSortPlayerMap2[i], speed * Time.deltaTime);
                    PlayerList[i].GetComponent<Rigidbody>().isKinematic = true;
                }
            }
           
        }
        Debug.Log("Sort");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stop Spawn")
        {
            sort = true;

            normalCamera = false;

            sortCamera = true;

            Debug.Log("Off");
        }

        if (other.tag == "Stop Spawn Map2")
        {
            sortMap2 = true;

            normalCamera = false;

            sortCameraMap2 = true;

            Debug.Log("Off");
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

        if (other.tag == "Wall Rotate")
        {
            rotationPlayer();

            isRotate = true;

            lockPosX = false;

            lockPosZ = true;

            moveX = false;

            RotatePos.gameObject.SetActive(false);

            Debug.Log("Rotate");
        }
    }

    IEnumerator _10PlayerSpawn()
    {
        
        for(int i = 0; i < 10; i++)
        {
            Vector3 spawnLocation = new Vector3(PlayerHolder.transform.position.x, PlayerHolder.transform.position.y, PlayerHolder.transform.position.z - 1) + 
                                    new Vector3(Random.onUnitSphere.x * Random.Range(-1.5f, 1.5f), 1, Random.onUnitSphere.z * Random.Range(-1.5f, 1.5f));

            GameObject playerClone = Instantiate(player,spawnLocation, PlayerHolder.transform.rotation);

            PlayerList.Add(playerClone);

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

            PlayerList.Add(playerClone);

            playerClone.transform.SetParent(PlayerHolder.transform);

            yield return new WaitForSeconds(0.1f);

            playerCount += 1;
        }
    }
}
