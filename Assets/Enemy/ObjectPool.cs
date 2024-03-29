using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer = 1f;
    [SerializeField] int poolSize = 5;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
       /* foreach (GameObject objectInPool in pool)
        {
            if(objectInPool.activeInHierarchy == false)
            {
                objectInPool.SetActive(true);
                return true;
            }
        }*/

        for(int i =0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            //Instantiate(enemyPrefab, transform);
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
