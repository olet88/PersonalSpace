using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy;

    bool hasSpawned = false;

    void Start()
    {
        player=GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasSpawned && Vector3.Distance(player.transform.position, transform.position) < 10)
        {
            hasSpawned = true;

            GameObject clone = Instantiate(enemy, transform.position, transform.rotation);
         //   clone.GetComponent<Movement>().player = player.transform;
           // clone.GetComponent<SeekTarget>().rb = clone.GetComponent<Rigidbody>();
        }
    }
}
