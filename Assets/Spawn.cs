using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform[] spawnPoint;
    public int numOfenemy = 4;

    BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }


    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int startCount = 0; startCount < numOfenemy; startCount++)
            {

                StartCoroutine(enemySpawn());

            }
            boxCollider.enabled = false;

        }
    }
    IEnumerator enemySpawn()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        Transform _sp = spawnPoint[Random.Range(0, spawnPoint.Length)];
        GameObject _Ep = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
        Instantiate(_Ep, _sp.position, _sp.rotation);



    }
}
