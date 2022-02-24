using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public static BulletMove Instance;

    public float speedBullet = 10f;

    public float timeDestroy = 1.5f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveBulletForward();

        if (PlayerCtrl.Instance.sort == true)
        {
            timeDestroy = 10f;
        }
    }

    void moveBulletForward()
    {
        transform.Translate(Vector3.forward * speedBullet * Time.deltaTime);
        StartCoroutine(AutoDestroy());
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(timeDestroy);

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);

            other.gameObject.SetActive(false);

            SpawnEnemy.Instance.listEnemy.RemoveRange(0, 1);
        }
    }
}
